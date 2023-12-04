using Common.Extensions;
using Common.Interfaces;

namespace _2015.Day02.Models;

public class Surface : IModel
{
    public IList<int> AreaDimensions => new[] { _length * _width, _width * _height, _height * _length };

    public IList<int> Perimeters => new[] { _length + _width, _width + _height, _height + _length };

    public int Volume => _length * _width * _height;

    private readonly int _length;
    private readonly int _width;
    private readonly int _height;
    
    public Surface(string line)
    {
        var items = line.Split('x', StringSplitOptions.RemoveEmptyEntries);
        _length = items[0].GetNumbers().First();
        _width = items[1].GetNumbers().First();
        _height = items[2].GetNumbers().First();
    }
}