namespace ThreadStartProject
{
    public class Product1<T>
    {
        public T Volume { get; set; }
        public T Energy { get; set; }


        public Product1(T volume, T energy)
        {
            // TODO: проверить входные параметры            
            Volume = volume;
            Energy = energy;


        }

    }
}