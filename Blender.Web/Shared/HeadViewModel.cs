using System;

namespace Blender.Web.Shared
{
    public class HeadViewModel
    {
        public event EventHandler<HeadViewModelChangedEventArgs> HeadViewModelChanged;
        
        public string Title { get; set; }
        
        public void RaiseHeadViewModelChanged()
        {
            HeadViewModelChanged?.Invoke(this, new HeadViewModelChangedEventArgs(this));
        }
    }
    
    public class HeadViewModelChangedEventArgs : EventArgs
    {
        public HeadViewModelChangedEventArgs(HeadViewModel headViewModel)
        {
            HeadViewModel = headViewModel;
        }

        public HeadViewModel HeadViewModel { get; }
    }
}