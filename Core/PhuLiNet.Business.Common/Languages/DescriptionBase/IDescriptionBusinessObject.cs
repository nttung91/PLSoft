namespace PhuLiNet.Business.Common.Languages.DescriptionBase
{
    public interface IDescriptionBusinessObject
    {
        /// <summary>
        /// The language of the description
        /// </summary>
        Language Language { get; set; }

        /// <summary>
        /// The description (i.e. long description)
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// The max length of long description used for MaxLength business rule and field limitation in GUI
        /// </summary>
        int? MaxLengthDescription { get; }

        /// <summary>
        /// The max length of short description used for MaxLength business rule and field limitation in GUI
        /// </summary>
        int? MaxLengthShortDescription { get; }

        /// <summary>
        /// The max length of 1st additional description used for MaxLength business rule and field limitation in GUI
        /// </summary>
        int? MaxLengthAdditionalDescription1 { get; }

        /// <summary>
        /// The max length of 2nd additional description used for MaxLength business rule and field limitation in GUI
        /// </summary>
        int? MaxLengthAdditionalDescription2 { get; }

        /// <summary>
        /// The max length of 3rd additional description used for MaxLength business rule and field limitation in GUI
        /// </summary>
        int? MaxLengthAdditionalDescription3 { get; }
    }
}