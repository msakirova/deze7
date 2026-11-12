namespace labTumakov.Class
{
    public class Song
    {
        private string _name;
        private string _author;
        private Song _prev;

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetAuthor(string author)
        {
            _author = author;
        }

        public void SetPrev(Song prev)
        {
            _prev = prev;
        }


        #region Вывод информации

        /// <summary>
        /// Возвращает название песни и имя автора
        /// </summary>
        public string Title()
        {
            return $"{_name} — {_author}";
        }

        /// <summary>
        /// Выводит информацию о песне
        /// </summary>
        public void PrintInformation()
        {
            Console.WriteLine(Title());
        }

        #endregion

        #region Сравнение песен

        /// <summary>
        /// Сравнивает две песни по названию и автору
        /// </summary>
        public override bool Equals(object d)
        {
            if (d is not Song song)
                return false;

            return _name == song._name && _author == song._author;
        }

        /// <summary>
        /// Возвращает хеш-код песни
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _author);
        }

        #endregion
    }
}
