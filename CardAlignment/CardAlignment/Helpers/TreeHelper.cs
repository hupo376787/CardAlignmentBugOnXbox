using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace CardAlignment.Helpers
{
    public class TreeHelper
    {
        //public static T FindChildOfType<T>(DependencyObject root) where T : class
        //{
        //    var MyQueue = new Queue<DependencyObject>();
        //    MyQueue.Enqueue(root);
        //    while (MyQueue.Count > 0)
        //    {
        //        DependencyObject current = MyQueue.Dequeue();
        //        if (current != null)
        //        {
        //            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
        //            {
        //                var child = VisualTreeHelper.GetChild(current, i);
        //                var typedChild = child as T;
        //                if (typedChild != null)
        //                {
        //                    return typedChild;
        //                }
        //                MyQueue.Enqueue(child);
        //            }
        //        }
        //    }
        //    return null;
        //}

        public static List<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            List<T> list = new List<T>();
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        list.Add((T)child);
                    }

                    List<T> childItems = FindVisualChildren<T>(child);
                    if (childItems != null && childItems.Count() > 0)
                    {
                        foreach (var item in childItems)
                        {
                            list.Add(item);
                        }
                    }
                }
            }
            return list;
        }

        public static TChild FindVisualChild<TChild>(DependencyObject obj) where TChild : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is TChild found)
                    return found;
                else
                {
                    TChild childOfChild = FindVisualChild<TChild>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}
