using System;
using System.ComponentModel;
using CoreGraphics;
using FFImageLoading.Args;
using FFImageLoading.Cross;
using FFImageLoading.Work;
using Foundation;
using MvvmCross.Platform;
using MvvmCross.Platform.WeakSubscription;

namespace Epam.GuestGuide.iOS.Controls
{
    [DesignTimeVisible(true)]
    [Category("Guest Guide Controls")]
    [Register("ImageLoadingView")]
    public class ImageLoadingView : MvxCachedImageView
    {
        private bool _bottomShadow;

        private bool _isLoaded;

        private MvxWeakEventSubscription<ImageLoadingView, FinishEventArgs>
            _imageLoadFinishedWeakEventSubscription;

        private MvxWeakEventSubscription<ImageLoadingView, DownloadStartedEventArgs>
            _imageLoadSuccesWeakEventSubscription;

        public ImageLoadingView()
        {
            SubscribeEvents();
            SetCustomDataResolver();
        }

        public ImageLoadingView(IntPtr handle) : base(handle)
        {
            SubscribeEvents();
            SetCustomDataResolver();
        }

        public ImageLoadingView(CGRect frame) : base(frame)
        {
            SubscribeEvents();
            SetCustomDataResolver();
        }

        [Export("BottomShadow")]
        [Browsable(true)]
        public bool BottomShadow
        {
            get { return _bottomShadow; }
            set
            {
                _bottomShadow = value;

                if (value)
                    Theme.DropShadow(this, 3, 0.1f);
            }
        }

        public event EventHandler IsLoadedChanged;

        public bool IsLoaded
        {
            get
            {
                return _isLoaded;
            }
            set
            {
                _isLoaded = value;
                IsLoadedChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void SetCustomDataResolver()
        {
            CustomDataResolver = Mvx.Resolve<IDataResolver>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnSubscribeEvents();
            }

            base.Dispose(disposing);
        }

        private void SubscribeEvents()
        {
            _imageLoadFinishedWeakEventSubscription =
                new MvxWeakEventSubscription<ImageLoadingView, FinishEventArgs>(
                    this,
                    "OnFinish",
                    OnImageLoaded);

            _imageLoadSuccesWeakEventSubscription =
                new MvxWeakEventSubscription<ImageLoadingView, DownloadStartedEventArgs>(
                    this,
                    "OnDownloadStarted",
                    OnImageDownloadStarted);
        }

        private void UnSubscribeEvents()
        {
            if (_imageLoadFinishedWeakEventSubscription != null)
            {
                _imageLoadFinishedWeakEventSubscription.Dispose();
                _imageLoadFinishedWeakEventSubscription = null;
            }

            if (_imageLoadSuccesWeakEventSubscription != null)
            {
                _imageLoadSuccesWeakEventSubscription.Dispose();
                _imageLoadSuccesWeakEventSubscription = null;
            }
        }

        private void OnImageDownloadStarted(object sender, DownloadStartedEventArgs e)
        {
            IsLoaded = false;
        }

        private void OnImageLoaded(object sender, FinishEventArgs finishEventArgs)
        {
            IsLoaded = true;
        }
    }
}