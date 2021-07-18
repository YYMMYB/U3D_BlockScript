using UnityEngine;

namespace Blocks {
    public class Killer : IBlock<BlockForms.Bind>, IFrameCmdSender {
        private Frame _frame;

        public void InitForm(IBlockForm form) {
            Form = (BlockForms.Bind) form;
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
            Frame.CmdMng.RemoveBlockCmd(this, Coord + Vector3.down);
        }
    }
}