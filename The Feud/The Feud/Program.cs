using IField;
using McDroid;
using IFPig = IField.Pig;
using MDPig = McDroid.Pig;

MDPig McdroidPig = new MDPig();
IFPig IFieldPig = new IFPig();
Sheep sheep = new Sheep();
Cow cow = new Cow();


namespace IField
{
    class Pig { }
    class Sheep { }
}
namespace McDroid
{
    class Pig { }
    class Cow { }
}