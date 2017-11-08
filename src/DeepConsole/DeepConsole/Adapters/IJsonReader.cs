namespace DeepConsole.Adapters
{
   public interface IJsonReader
   {
      T ReadAllText<T>( string path );
   }
}
