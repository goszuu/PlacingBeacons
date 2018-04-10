using PlacingBeacons.Pages;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PlacingBeacons
{
    public partial class PlacingBeaconsPage : ContentPage
    {
        AbsoluteLayout layout;
        Slider sliderX, sliderY;
        Image mapImage, circleblue, beaconImage, currentImage, beaconImage1, pImage,tempImage;
       
        double csize = .15;
        Button add, remove, push;
        public List<Image> beaconImages;
        int clickTotal = 0;
        Label clicks;
        TapGestureRecognizer tapGestureRecognizer;
        

        public PlacingBeaconsPage()
        {
            
            InitializeComponent();
            layout = new AbsoluteLayout();
            beaconImages = new List<Image>();

            mapImage = new Image
            {
                Source = "szkolarzut.png",
                Aspect = Aspect.Fill

            };
            AbsoluteLayout.SetLayoutBounds(mapImage, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(mapImage, AbsoluteLayoutFlags.All);

            circleblue = new Image
            {
                Source = "circleblue.png",
                IsVisible = true
                
            };
            
            AbsoluteLayout.SetLayoutBounds(circleblue, new Rectangle(.5, .5, csize, csize));
            AbsoluteLayout.SetLayoutFlags(circleblue, AbsoluteLayoutFlags.All);

            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {
                currentImage.Source = "circle.png";
                tempImage = (Image)sender;
                currentImage = tempImage;
                currentImage.Source = "circleblue.png";



            };
            circleblue.GestureRecognizers.Add(tapGestureRecognizer);


            sliderX = new Slider
            {
                Maximum = 1 + csize / 2,
                Minimum = 0 - csize / 2,
                Value = 0.5,
                IsVisible = false
            };
            sliderX.ValueChanged += Slider_ValueChanged;
            AbsoluteLayout.SetLayoutBounds(sliderX, new Rectangle(.5, .8, 1, .1));
            AbsoluteLayout.SetLayoutFlags(sliderX, AbsoluteLayoutFlags.All);

            sliderY = new Slider
            {
                Maximum = 1 + csize / 2,
                Minimum = 0 - csize / 2,
                Value = 0.5,
                IsVisible = false
        

            };
            sliderY.ValueChanged += Slider_ValueChanged;
            AbsoluteLayout.SetLayoutBounds(sliderY, new Rectangle(.8, .95, 1, .1));
            AbsoluteLayout.SetLayoutFlags(sliderY, AbsoluteLayoutFlags.All);

            currentImage = circleblue;
            

            
            add = new Button
            {
                Text = "Dodaj beacon"
            };
            add.Clicked += Add_Clicked;
            AbsoluteLayout.SetLayoutBounds(add, new Rectangle(.5, .7, .3, .1));
            AbsoluteLayout.SetLayoutFlags(add, AbsoluteLayoutFlags.All);

            remove = new Button
            {
                Text = "Usuń beacon",
                IsVisible = false
            };
            
            remove.Clicked += Remove_Clicked;
            AbsoluteLayout.SetLayoutBounds(remove, new Rectangle(.5, .88, .3, .1));
            AbsoluteLayout.SetLayoutFlags(remove, AbsoluteLayoutFlags.All);

            push = new Button
            {
                Text = "Wyświetl dane beacon'ów"
            };
            push.Clicked += Push_Clicked;
            pImage = beaconImage1;
       
            layout.Children.Add(mapImage);
            layout.Children.Add(circleblue);           
            layout.Children.Add(add);         
            layout.Children.Add(currentImage);
            layout.Children.Add(sliderX);
            layout.Children.Add(sliderY);
            layout.Children.Add(remove);
            layout.Children.Add(push);
            Content = layout;

           

            
        }
        
        void Add_Clicked(object sender, System.EventArgs e)
        {
            remove.IsVisible = true;
            sliderX.IsVisible = true;
            sliderY.IsVisible = true;
            currentImage.Source = "circle.png";
            beaconImage = new Image
            {
                Source = "circleblue.png"
            };
            beaconImage.GestureRecognizers.Add(tapGestureRecognizer);
            AbsoluteLayout.SetLayoutBounds(beaconImage, new Rectangle(sliderX.Value, sliderY.Value, csize, csize));
            AbsoluteLayout.SetLayoutFlags(beaconImage, AbsoluteLayoutFlags.All);
            
            beaconImages.Add(beaconImage);

            currentImage = beaconImage;
            layout.Children.Add(beaconImage);
            clickTotal += 1;
        }

        void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AbsoluteLayout.SetLayoutBounds(currentImage, new Rectangle(sliderX.Value, sliderY.Value, csize, csize));
           
        }
        void Remove_Clicked(object sender, System.EventArgs e)
        {

            layout.Children.Remove(currentImage);

        }
        void Push_Clicked(object sender, System.EventArgs e) => Navigation.PushModalAsync(new Page1());

    }
    }
    
