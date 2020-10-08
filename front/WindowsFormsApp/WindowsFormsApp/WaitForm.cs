using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class WaitForm : Form
    {
        public Action Worker { get; set; }

        public WaitForm(Action worker)
        {
            InitializeComponent();
            Worker = worker ?? throw new ArgumentNullException();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

    }
}
