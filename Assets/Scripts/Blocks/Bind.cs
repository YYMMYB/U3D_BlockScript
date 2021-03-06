using UnityEngine;

namespace Blocks {
    public class Bind : IBlock<BlockForms.Bind>, IFrameCmdSender {
        private Frame _frame;

        public void InitForm(IBlockForm form) {
            Form = form as BlockForms.Bind;
        }

        public BlockForms.Bind Form { get; protected set; }

        IBlockForm IBlock.Form => Form;

        public Coord Coord { get; set; }

        public Frame Frame
        {
            get => _frame;
            set
            {
                if (_frame != null) {
                    _frame.CmdMng.UnrigisterSender(this);
                }

                _frame = value;
                if (_frame != null) {
                    _frame.CmdMng.RigisterSender(this);
                }
            }
        }

        public bool isInFrame { get; set; }
        public int? BindId { get; set; }

        public void RegisterCmds() {
            Frame.CmdMng.BindBlocksCmd(this, new CoordInt[] {
                Coord + Vector3.up,
                Coord + Vector3.up * 2,
            });
        }
    }
}