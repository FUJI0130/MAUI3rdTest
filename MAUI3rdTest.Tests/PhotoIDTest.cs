using Domain.ValueObjects;

namespace MAUI3rdTest.Tests;

public class PhotoIDTest
{
	// TODO: Add some unit tests
	[Fact]
	public void 数値を文字列に変更する()
	{

	}

    [Fact]
    public void double型に変更する()
    {

    }

    [Fact]
    public void PhotoID_Equals()
    {
        var t1 = new PhotoID(1);
        var t2 = new PhotoID(1);
        Assert.Equal(t1, t2);
    }
    
    [Fact]
    public void PhotoID_EqualsEquals()
    {
        var t1 = new PhotoID(1);
        var t2 = new PhotoID(1);
        Assert.Equal(true, t1==t2);
    }
}
