using Avalonia.Controls;

namespace FurCard.Views
{
    public partial class CharView : UserControl
    {
        public CharView()
        {
            InitializeComponent();
        }

        // TODO: Find a better way to do this
        protected override void OnSizeChanged(SizeChangedEventArgs e)
        {
            if (e.WidthChanged)
            {
                if (e.NewSize.Width < 800)
                {
                    MainView.Orientation = Avalonia.Layout.Orientation.Vertical;
                }
                else
                {
                    MainView.Orientation = Avalonia.Layout.Orientation.Horizontal;
                }
            }
        }
    }
}
