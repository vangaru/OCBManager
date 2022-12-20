using OCBManager.Domain.Models;

namespace OCBManager.Domain.Parsing
{
    public interface ISheetParser
    {
        public TurnoverSheet Parse(string path);
    }
}
