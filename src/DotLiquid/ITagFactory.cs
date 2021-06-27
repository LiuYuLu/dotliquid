namespace DotLiquid
{
    /// <summary>
    /// Tag工厂方法接口
    /// </summary>
    /// <remarks>Can be usefull when the tag needs a parameter and can't be created with parameterless constructor.</remarks>
    public interface ITagFactory
    {
        /// <summary>
        /// 获取Tag的名称
        /// </summary>
        string TagName { get; }

        /// <summary>
        /// 创建Tag
        /// </summary>
        /// <returns></returns>
        Tag Create();
    }
}
