namespace Docs.Core {
    public class Heading {
        public string ID { get; private set; }
        public int Level { get; private set; }
        public string Text { get; private set; }

        public Heading(string id, int level, string text) {
            ID = id;
            Level = level;
            Text = text;
        }
    }
}
