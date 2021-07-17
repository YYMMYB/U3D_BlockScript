namespace Blocks {
    public class Bind : IBlock<BlockForms.Bind> , IFrameCmdSender{
        public void InitForm(IBlockForm form) {
            Form = form as BlockForms.Bind;
        }

        public BlockForms.Bind Form { get; protected set; }

        IBlockForm IBlock.Form => Form;

        public Coord Coord { get; set; }
        public Frame Frame { get; set; }
        public bool isInFrame { get; set; }
        public int? BindId { get; set; }
    }
}