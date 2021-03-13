
namespace Calculator
{
    interface IData
    {
        string DataEntry( out string[] symbol);

        void OutputDisplay(double result);

        void ReaderDataBase();

        void DeleteDataBase();

        void CreateDataTable();
    }
}
