using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using EstudoPAM.Models;
using EstudoPAM.Services;

namespace EstudoPAM.ViewModel
{
    public partial class PostViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> _posts;

        public ICommand getPostsCommand { get; }

        public PostViewModel()
        {
            getPostsCommand = new Command(getPosts);
        }

        public async void getPosts()
        {
            PostService postService = new();
            Posts = await postService.getPosts();
        }
}
}
