using System.Threading;
using System.Windows;
using InterviewTest.App.RemoteWorkerSimulator_DO_NOT_TOUCH;

namespace InterviewTest.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region DO NOT REMOVE

        private CancellationTokenSource _cancellationTokenSource;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _cancellationTokenSource = new CancellationTokenSource();
            new RemoteProductWorkerSimulator().Run(_cancellationTokenSource.Token);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            _cancellationTokenSource.Cancel();
        }

        #endregion DO NOT REMOVE
    }
}