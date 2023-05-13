using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IRNA.Web.ViewModels
{
    public class ContentViewModel
    {
    }
    public class ContentListVM
    {
        public int id { get; set; }
        public bool music { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string castAndCrew { get; set; }
        public int date { get; set; }
        public int jalaliDate { get; set; }
        public string screenShot { get; set; }
        public int price { get; set; }
        public object priceWithoutDiscount { get; set; }
        public int staffRate { get; set; }
        public int commentRate { get; set; }
        public object gallery { get; set; }
        public object attachments { get; set; }
        public int numberOfComments { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }
        public int totalLength { get; set; }
        public bool collection { get; set; }
        public bool podcast { get; set; }
        public bool hd { get; set; }
        public object parentIds { get; set; } 
    }

    public class CommentVM
    { 
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string body { get; set; } 
    }

    public class ContentResponseVM
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfRecords { get; set; }
        public int numberOfPages { get; set; }
        public string root { get; set; }
        public string galleryRoot { get; set; }
        public object priceUnit { get; set; }
        public List<ContentListVM> list { get; set; }
        public object info { get; set; } 
    }



    public class CommentListVM
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfRecords { get; set; }
        public int numberOfPages { get; set; }
        public string root { get; set; }
        public string galleryRoot { get; set; }
        public object priceUnit { get; set; }
        public List<CommentListVM> list { get; set; }
        public object info { get; set; }
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string body { get; set; }
        public long sendTime { get; set; }
        public object approvedTime { get; set; }
        public bool approved { get; set; }
        public string language { get; set; }
        public bool ltr { get; set; }
        public int diskId { get; set; }
        public object rate { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }
        public object liked { get; set; }
        public object disliked { get; set; }
    }

    public class LocalizedMessagesCommentVM
    {
        public string ar { get; set; }
        public string en { get; set; }
        public string fa { get; set; }
    }

    public class MoreCommentVM
    {
        public CommentListVM list { get; set; }
    }

    public class RootCommentVM
    {
        public int code { get; set; }
        public LocalizedMessagesCommentVM localizedMessages { get; set; }
        public MoreCommentVM more { get; set; }
    }

    public class ContentFilterVM
    {
        public bool music { get; set; }
        public string keyword { get; set; }
        public bool free { get; set; }
        public bool selected { get; set; }
        public bool special { get; set; }
        public string ids { get; set; }
        public string artists { get; set; }
        public int tagId { get; set; }
        public string genres { get; set; }
        public string prizes { get; set; }
        public string subtitles { get; set; }
        public string qualityTypes { get; set; }
        public string ageGroups { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
        public int minYear { get; set; }
        public int maxYear { get; set; }
        public string countries { get; set; }
        public bool gallery { get; set; }
        public bool collection { get; set; }
        public string classes { get; set; }
        public string lang { get; set; }
        public int Id { get; set; }
    }





    //Content Details

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AgeGroupVM
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class ClassContentDetailsVM
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ContentDetailsVM
    {
        public int id { get; set; }
        public int diskId { get; set; }
        public string title { get; set; }
        public string diskTitle { get; set; }
        public int length { get; set; }
        public string lengthText { get; set; }
        public string filename { get; set; }
        public string extension { get; set; }
        public bool disabled { get; set; }
        public object trackOrEpisode { get; set; }
        public List<int> qualityIds { get; set; }
        public List<string> qualityTypes { get; set; }
        public bool abr { get; set; }
    }

    public class CountryVM
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class DiscountVM
    {
        public int code { get; set; }
        public LocalizedMessagesVM localizedMessages { get; set; }
        public MoreVM more { get; set; }
    }

    public class GalleryVM
    {
        public string root { get; set; }
        public string root2 { get; set; }
        public List<TypeVM> types { get; set; }
        public string code { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int numberOfFiles { get; set; }
    }

    public class GenreVM
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class IsBoughtVM
    {
        public string status { get; set; }
        public int code { get; set; }
        public string text { get; set; }
    }

    public class IsPostPaidVM
    {
        public string status { get; set; }
        public int code { get; set; }
        public string text { get; set; }
    }

    public class LocalizedMessagesVM
    {
        public string en { get; set; }
        public string fa { get; set; }
    }

    public class MoreVM
    {
        public int answer { get; set; }
    }

    public class NumberOfPlaysVM
    {
        public int _133 { get; set; }
    }

    public class ParentVM
    {
        public int id { get; set; }
        public bool music { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string castAndCrew { get; set; }
        public int date { get; set; }
        public int jalaliDate { get; set; }
        public string screenShot { get; set; }
        public int price { get; set; }
        public object priceWithoutDiscount { get; set; }
        public int staffRate { get; set; }
        public int commentRate { get; set; }
        public List<GalleryVM> gallery { get; set; }
        public object attachments { get; set; }
        public int numberOfComments { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }
        public int totalLength { get; set; }
        public bool collection { get; set; }
        public bool podcast { get; set; }
        public bool hd { get; set; }
        public object parentIds { get; set; }
    }

    public class PrizeVM
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class ProviderVM
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class QualityVM
    {
        public int id { get; set; }
        public string @string { get; set; }
        public int number { get; set; }
    }

    public class RateVM
    {
        public int staffRate { get; set; }
        public int numberOfStaffs { get; set; }
        public int userRate { get; set; }
        public int commentRate { get; set; }
        public int numberOfUsers { get; set; }
        public int numberOfComments { get; set; }
        public int numberOfLikes { get; set; }
        public int numberOfDislikes { get; set; }
        public int consumed { get; set; }
        public long addedTime { get; set; }
        public int buyed { get; set; }
    }

    public class Role
    {
        public int artistId { get; set; }
        public string title { get; set; }
        public int roleId { get; set; }
        public string roleTitle { get; set; }
    }

    public class RootContentDetailsVM
    {
        public VodResultVM vodResult { get; set; }
        public IsBoughtVM isBought { get; set; }
        public IsPostPaidVM isPostPaid { get; set; }
        public DiscountVM discount { get; set; }
        public StatsVM stats { get; set; }
        public LikeRootVM LikeRoot { get; set; }
    }

    public class StatsVM
    {
        public NumberOfPlaysVM numberOfPlays { get; set; }
        public int numberOfBuys { get; set; }
        public int numberOfViews { get; set; }
        public long numberOfViewsSince { get; set; }
    }

    public class TagVM
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class TypeVM
    {
        public string code { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int numberOfFiles { get; set; }
    }

    public class VodResultVM
    {
        public GalleryVM gallery { get; set; }
        public int id { get; set; }
        public bool collection { get; set; }
        public bool podcast { get; set; }
        public int price { get; set; }
        public int priceWithoutDiscount { get; set; }
        public string priceUnit { get; set; }
        public string defaultTitle { get; set; }
        public string name { get; set; }
        public string castAndCrew { get; set; }
        public string description { get; set; }
        public int year { get; set; }
        public int jalaliYear { get; set; }
        public int gregorianYear { get; set; }
        public bool subtitle { get; set; }
        public bool recordable { get; set; }
        public string screenshot { get; set; }
        public string screenShot { get; set; }
        public string screenShotRoot { get; set; }
        public bool music { get; set; }
        public bool downloadable { get; set; }
        public int date { get; set; }
        public bool disabled { get; set; }
        public object folder { get; set; }
        public object seasonOrDisk { get; set; }
        public object imid { get; set; }
        public int rateOfUser { get; set; }
        public int numberOfUserRates { get; set; }
        public int totalDuration { get; set; }
        public string totalDurationText { get; set; }
        public AgeGroupVM ageGroup { get; set; }
        public CountryVM country { get; set; }
        public List<Role> roles { get; set; }
        public List<object> attachments { get; set; }
        public List<PrizeVM> prizes { get; set; }
        public List<TagVM> tags { get; set; }
        public List<ProviderVM> providers { get; set; }
        public string criticize { get; set; }
        public int commentRate { get; set; }
        public bool liked { get; set; }
        public bool disliked { get; set; }
        public bool hd { get; set; }
        public bool child { get; set; }
        public List<int> parentIds { get; set; }
        public List<ClassContentDetailsVM> classes { get; set; }
        public List<object> artists { get; set; }
        public List<GenreVM> genres { get; set; }
        public List<ContentDetailsVM> contents { get; set; }
        public List<object> children { get; set; }
        public List<ParentVM> parents { get; set; }
        public List<QualityVM> qualities { get; set; }
        public RateVM rate { get; set; }
    }


    //Filter viewmodel


    public class AgeGroupFilterVM
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class CountryFilterVM
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class GenresFilterVM
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfRecords { get; set; }
        public int numberOfPages { get; set; }
        public string root { get; set; }
        public string galleryRoot { get; set; }
        public object priceUnit { get; set; }
        public List<ListFilterVM> list { get; set; }
        public object info { get; set; }
    }

    public class ListFilterVM
    {
        public int id { get; set; }
        public bool music { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
        public object gallery { get; set; }
    }

    public class LocalizedMessagesFilterVM
    {
        public string ar { get; set; }
        public string en { get; set; }
        public string fa { get; set; }
    }

    public class MoreFilterVM
    {
        public List<object> boldTags { get; set; }
        public GenresFilterVM genres { get; set; }
        public PrizesFilterVM prizes { get; set; }
        public List<QualityTypeFilterVM> qualityTypes { get; set; }
        public List<CountryFilterVM> countries { get; set; }
        public List<AgeGroupFilterVM> ageGroups { get; set; }
    }

    public class PrizesFilterVM
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfRecords { get; set; }
        public int numberOfPages { get; set; }
        public string root { get; set; }
        public string galleryRoot { get; set; }
        public object priceUnit { get; set; }
        public List<ListFilterVM> list { get; set; }
        public object info { get; set; }
    }

    public class QualityTypeFilterVM
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class RootFilterVM
    {
        public int code { get; set; }
        public LocalizedMessagesFilterVM localizedMessages { get; set; }
        public MoreFilterVM more { get; set; }
    }


    public class ListGenresVM
    {
        public int id { get; set; }
        public bool music { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
        public object gallery { get; set; }
    }

    public class RootGenresVM
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfRecords { get; set; }
        public int numberOfPages { get; set; }
        public string root { get; set; }
        public string galleryRoot { get; set; }
        public object priceUnit { get; set; }
        public List<ListGenresVM> list { get; set; }
        public object info { get; set; }
    }

    public class LikeListVM
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public int diskId { get; set; }
    }

    public class LikeRootVM
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfRecords { get; set; }
        public int numberOfPages { get; set; }
        public string root { get; set; }
        public string galleryRoot { get; set; }
        public object priceUnit { get; set; }
        public List<LikeListVM> list { get; set; }
        public object info { get; set; }
    }



    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class LocalizedMessagesLanguageViewModel
    {
        public string ar { get; set; }
        public string en { get; set; }
        public string fa { get; set; }
    }

    public class MorePlayedViewModel
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public List<string> list { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int numberOfPages { get; set; }
        public int numberOfRows { get; set; }
    }

    public class RootPlayedViewModel
    {
        public int code { get; set; }
        public LocalizedMessagesLanguageViewModel localizedMessages { get; set; }
        public MorePlayedViewModel more { get; set; }
    }



}