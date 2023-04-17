namespace MAUI3rdTest.ViewModels;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


//それぞれnewしてからビルドは通った。　後でViewModelの中でSetPropertyが機能するか確認したい

public abstract class ViewModel :ObservableObject //☆ここをObservableObject  //: INotifyPropertyChanged　//これにするとビルド通らなかった。
{
    public new event PropertyChangedEventHandler PropertyChanged;//new書いてみた


    //●ObservableObjectの中に、SetPropertyが実装されているらしいので、それの私用を調べてみたい
    //もし、ここに書いている内容と同じ様な処理であれば、ここに書いているのは書かずに使えるかも？？

    //もしくはここでnew書くだけで使える？？

    protected new bool SetProperty<T>(ref T field,//new書いてみた
        T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(field, value))
        {
            return false;
        }

        field = value;
        var h = this.PropertyChanged;
        if (h != null)
        {
            h(this, new PropertyChangedEventArgs(propertyName));
        }

        return true;
    }
    public virtual DateTime GetDateTime()
    {
        return DateTime.Now;
    }
}
