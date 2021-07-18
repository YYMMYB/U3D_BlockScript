namespace Blocks {
    public class TestBlock : IBlock
    {
        public void InitForm(IBlockForm form) {
            Form = form;
        }

        public IBlockForm Form { get; private set; }
        public Coord Coord { get; set; }
        public Frame Frame { get; set; }
        public bool isInFrame { get; set; }
        public int? BindId { get; set; }
    }
}