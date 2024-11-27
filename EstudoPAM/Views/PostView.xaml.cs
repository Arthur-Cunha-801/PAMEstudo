namespace EstudoPAM.Views;
using EstudoPAM.ViewModel;

public partial class PostView : ContentPage
{
	public PostView()
	{
		InitializeComponent();
        BindingContext = new PostViewModel();
    }
}