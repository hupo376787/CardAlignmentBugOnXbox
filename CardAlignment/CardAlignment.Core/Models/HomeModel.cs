using System.Collections.Generic;

namespace CardAlignment.Core.Models
{
    public class HomeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Status status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Server server { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<BannerItem> banner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<GridItem> grid { get; set; }
    }

    public class GridItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string grid_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sequence_number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string style { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string data_type { get; set; }
        /// <summary>
        /// 最新更新
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 最新更新
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string background_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover_image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ProductItem> product { get; set; }
    }

    public class ProductItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sequence_number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title_background_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string use_series_title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string series_id { get; set; }
        /// <summary>
        /// 德久，很久不见了
        /// </summary>
        public string synopsis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string allow_download { get; set; }
        /// <summary>
        /// int type maybe small for this field, use long instead
        /// </summary>
        public long free_time { get; set; }
        /// <summary>
        /// 特别勤务监督官赵昌风
        /// </summary>
        public string series_name { get; set; }
        /// <summary>
        /// 韩剧
        /// </summary>
        public string series_category_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string series_category_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cover_image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string focus_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string focus_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string focus_start_section { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string focus_time_duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string series_image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_movie { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product_image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int is_parental_lock_limited { get; set; }
    }

    public class BannerItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string sequence_number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string banner_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string release_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image_navigation_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string image_click_url { get; set; }
        /// <summary>
        /// 独家追播
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title_background_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string background_color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_ad { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string series_id { get; set; }
        /// <summary>
        /// 各位国民
        /// </summary>
        public string series_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> series_update_cycle { get; set; }
        /// <summary>
        /// 韩剧
        /// </summary>
        public string series_category_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string series_category_id { get; set; }
        /// <summary>
        /// 反击
        /// </summary>
        public string product_synopsis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product_number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string allow_download { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product_schedule_start_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product_schedule_end_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long product_free_time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long is_parental_lock_limited { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product_cover_image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string product_image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string series_image_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_movie { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string series_update_cycle_description { get; set; }
    }

    public class Status
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }
    }

    public class LanguageItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string language_flag_id { get; set; }
        /// <summary>
        /// 简体中文
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string mark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string is_default { get; set; }
    }

    public class Area
    {
        /// <summary>
        /// 
        /// </summary>
        public int area_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LanguageItem> language { get; set; }
    }

    public class Server
    {
        /// <summary>
        /// 
        /// </summary>
        public int time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Area area { get; set; }
    }
}
