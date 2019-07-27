using System.Threading;
using System.Threading.Tasks;

namespace Omnix.Base
{
    public enum ServiceStateType
    {
        Starting,
        Running,
        Stopping,
        Stopped,
    }

    /// <summary>
    /// Statefulなクラスの実行状態を管理します。
    /// </summary>
    public abstract class ServiceBase : DisposableBase, IService
    {
        private int _initialized = 0;
        private readonly AsyncLock _asyncLock = new AsyncLock();

        public virtual ServiceStateType StateType { get; protected set; }

        protected abstract ValueTask OnInitializeAsync();
        protected abstract ValueTask OnStartAsync();
        protected abstract ValueTask OnStopAsync();

        protected virtual async ValueTask InitializeAysnc()
        {
            // 初期化済みの場合は処理しない
            if (Interlocked.CompareExchange(ref _initialized, 1, 0) == 1)
            {
                return;
            }

            await this.OnInitializeAsync();
        }

        public virtual async ValueTask StartAsync()
        {
            using (await _asyncLock.LockAsync())
            {
                await this.InitializeAysnc();

                if (this.StateType != ServiceStateType.Stopped)
                {
                    return;
                }

                await this.OnStartAsync();
            }
        }

        public virtual async ValueTask StopAsync()
        {
            using (await _asyncLock.LockAsync())
            {
                if (this.StateType != ServiceStateType.Running)
                {
                    return;
                }

                await this.OnStopAsync();
            }
        }

        public virtual async ValueTask RestartAsync()
        {
            using (await _asyncLock.LockAsync())
            {
                if (this.StateType != ServiceStateType.Stopped)
                {
                    await this.OnStopAsync();
                }

                await this.OnStartAsync();
            }
        }
    }
}
