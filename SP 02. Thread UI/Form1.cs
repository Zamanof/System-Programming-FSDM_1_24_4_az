namespace SP_02._Thread_UI
{
    public partial class Form1 : Form
    {
        
        static int i = 0;
        Thread thread = default;
        public Form1()
        {
            InitializeComponent();
            

            
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            thread = new Thread(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    countLabel.Text = i.ToString();
                    Thread.Sleep(1000);
                }
            });
            thread.IsBackground = true;
            thread.Start();
            startButton.Enabled = false;
        }

        
    }
}
