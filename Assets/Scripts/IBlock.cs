public interface IBlock<T> : IBlock
    where T : IBlockForm {
    T Form { get; }
}

public interface IBlock {
    void InitForm(IBlockForm form);
    IBlockForm Form { get; }
    Coord Coord { get; set; }
    Frame Frame { get; set; }
    bool isInFrame { get; set; }
    int? BindId { get; set; }
}