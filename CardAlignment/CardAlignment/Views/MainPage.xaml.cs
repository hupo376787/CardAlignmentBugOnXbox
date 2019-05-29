using CardAlignment.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Newtonsoft.Json;
using Windows.Storage;
using System.Threading.Tasks;
using CardAlignment.Core.Models;

namespace CardAlignment.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        //Store index in each river
        private List<int> listIndexsInEachRiver;
        //All rivers
        List<GridView> listRivers = new List<GridView>();
        //Initial river index should be at 0, when press up/down key each time, this updates like ++/--
        int riverIndexInAllRivers = 0;

        HomeModel hm;

        public MainPage()
        {
            InitializeComponent();

            GetData();
        }

        private async Task GetData()
        {
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/data.json"));
            string text = await FileIO.ReadTextAsync(file);

            hm = JsonConvert.DeserializeObject<HomeModel>(text);
            if(hm != null)
                list.ItemsSource = hm.data.grid;
        }

        private void GridItem_Loaded(object sender, RoutedEventArgs e)
        {
            var root = (UIElement)sender;
            GridAnimationHelper.InitializeAnimation(root, TreeHelper.FindVisualChild<Canvas>(root));
        }

        private void ListView_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            list.UpdateLayout();

            if (listIndexsInEachRiver == null)
            {
                //Stores all gridviews(one row enabled)
                listRivers = TreeHelper.FindVisualChildren<GridView>(list);
                //Stores the selected index item of each river
                listIndexsInEachRiver = new List<int>();
                foreach (var item in listRivers)
                {
                    listIndexsInEachRiver.Add(item.SelectedIndex);
                }
            }

            //Declare:
            //Each river contains a title and a gridview(one row enabled). Remember it!!!

            //Current river
            var listItem = list.ContainerFromIndex(riverIndexInAllRivers) as ListViewItem;
            //Current GridView in current river
            var currentRiver = TreeHelper.FindVisualChild<GridView>(listItem);
            Debug.WriteLine("currentRiver.ActualWidth: " + currentRiver.ActualWidth);

            //Current item index in current river
            int itemIndexInCurrentRiver = currentRiver.SelectedIndex;

            //Current river index in all rivers
            //int riverIndexInCurrentRivers = listRivers.IndexOf(currentRiver);

            switch (e.Key)
            {
                case VirtualKey.Down:
                case VirtualKey.GamepadDPadDown:
                case VirtualKey.GamepadLeftThumbstickDown:
                    if (riverIndexInAllRivers + 1 < listRivers.Count)
                    {
                        var nextRiver = listRivers[riverIndexInAllRivers + 1];
                        nextRiver.Focus(FocusState.Programmatic);
                        if (nextRiver.Items != null && nextRiver.Items.Count > 0)
                        {
                            GridViewItem item = new GridViewItem();
                            if (listIndexsInEachRiver[riverIndexInAllRivers + 1] == -1)
                            {
                                item = nextRiver.ContainerFromIndex(0) as GridViewItem;
                                listIndexsInEachRiver[riverIndexInAllRivers + 1] = 0;
                            }
                            else
                            {
                                item = nextRiver.ContainerFromIndex(listIndexsInEachRiver[riverIndexInAllRivers + 1]) as GridViewItem;
                                listIndexsInEachRiver[riverIndexInAllRivers] = itemIndexInCurrentRiver;
                            }

                            item.Focus(FocusState.Programmatic);
                            item.IsSelected = true;
                            item.StartBringIntoView();
                        }

                        riverIndexInAllRivers++;
                    }

                    e.Handled = true;
                    break;
                case VirtualKey.Up:
                case VirtualKey.GamepadDPadUp:
                case VirtualKey.GamepadLeftThumbstickUp:
                    if (riverIndexInAllRivers - 1 >= 0)
                    {
                        var previousRiver = listRivers[riverIndexInAllRivers - 1];
                        previousRiver.Focus(FocusState.Programmatic);
                        if (previousRiver.Items != null && previousRiver.Items.Count > 0)
                        {
                            GridViewItem item = new GridViewItem();
                            if (listIndexsInEachRiver[riverIndexInAllRivers - 1] == -1) //Probably never happen
                            {
                                item = previousRiver.ContainerFromIndex(0) as GridViewItem;
                                listIndexsInEachRiver[riverIndexInAllRivers] = 0;
                            }
                            else
                            {
                                item = previousRiver.ContainerFromIndex(listIndexsInEachRiver[riverIndexInAllRivers - 1]) as GridViewItem;
                                listIndexsInEachRiver[riverIndexInAllRivers] = itemIndexInCurrentRiver;
                            }

                            item.Focus(FocusState.Programmatic);
                            item.IsSelected = true;
                            item.StartBringIntoView();
                        }

                        riverIndexInAllRivers--;
                    }

                    e.Handled = true;
                    break;
                case VirtualKey.Left:
                case VirtualKey.GamepadDPadLeft:
                case VirtualKey.GamepadLeftThumbstickLeft:
                    if (itemIndexInCurrentRiver - 1 >= 0)
                    {
                        currentRiver.Focus(FocusState.Programmatic);

                        GridViewItem item = new GridViewItem();
                        item = currentRiver.ContainerFromIndex(listIndexsInEachRiver[riverIndexInAllRivers]) as GridViewItem;
                        listIndexsInEachRiver[riverIndexInAllRivers] = itemIndexInCurrentRiver - 1;

                        item.Focus(FocusState.Programmatic);
                        item.IsSelected = true;
                        item.StartBringIntoView();

                        e.Handled = false;
                    }
                    else
                        e.Handled = true;
                    break;
                case VirtualKey.Right:
                case VirtualKey.GamepadDPadRight:
                case VirtualKey.GamepadLeftThumbstickRight:
                    if (itemIndexInCurrentRiver + 1 <= currentRiver.Items.Count - 1)
                    {
                        currentRiver.Focus(FocusState.Programmatic);

                        GridViewItem item = new GridViewItem();
                        item = currentRiver.ContainerFromIndex(listIndexsInEachRiver[riverIndexInAllRivers]) as GridViewItem;
                        listIndexsInEachRiver[riverIndexInAllRivers] = itemIndexInCurrentRiver + 1;

                        item.UpdateLayout();
                        item.Focus(FocusState.Programmatic);
                        item.IsSelected = true;
                        item.StartBringIntoView();

                        e.Handled = false;
                    }
                    else
                        e.Handled = true;
                    break;
                default:
                    break;
            }
        }

        private void Button_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            list.UpdateLayout();

            switch (e.Key)
            {
                case VirtualKey.Down:
                case VirtualKey.GamepadDPadDown:
                case VirtualKey.GamepadLeftThumbstickDown:
                    //Stores all gridviews(one row enabled)
                    if (listRivers.Count == 0)
                        listRivers = TreeHelper.FindVisualChildren<GridView>(list);
                    //Stores the selected index item of each river
                    if (listIndexsInEachRiver == null || listIndexsInEachRiver.Count == 0)
                    {
                        listIndexsInEachRiver = new List<int>();
                        foreach (var item in listRivers)
                        {
                            listIndexsInEachRiver.Add(item.SelectedIndex);
                        }
                    }

                    if (list != null && list.Items.Count > 0)
                    {
                        //Find the first river, including a textblock and a adaptive gridview
                        var firstRiver = list.ContainerFromIndex(0) as ListViewItem;
                        var gridview = TreeHelper.FindVisualChild<GridView>(firstRiver);
                        if (gridview != null && gridview.Items.Count > 0)
                        {
                            GridViewItem item = new GridViewItem();
                            if (listIndexsInEachRiver[0] == -1)
                            {
                                item = gridview.ContainerFromIndex(0) as GridViewItem;
                                listIndexsInEachRiver[0] = 0;
                            }
                            else
                            {
                                item = gridview.ContainerFromIndex(listIndexsInEachRiver[0]) as GridViewItem;
                                listIndexsInEachRiver[0] = gridview.SelectedIndex;
                            }

                            item.Focus(FocusState.Programmatic);
                            item.IsSelected = true;
                            e.Handled = true;
                        }
                    }

                    e.Handled = true;
                    break;
                case VirtualKey.Up:
                case VirtualKey.GamepadDPadUp:
                case VirtualKey.GamepadLeftThumbstickUp:
                    //Do nothing

                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            btn.Focus(FocusState.Pointer);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    }
}
