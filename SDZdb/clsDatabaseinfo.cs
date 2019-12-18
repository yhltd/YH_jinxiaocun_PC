using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDZdb
{
    public class clsuserinfo
    {
        public string Order_id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string Btype { get; set; }
        public string denglushijian { get; set; }
        public string Createdate { get; set; }
        public string AdminIS { get; set; }
        public string jigoudaima { get; set; }
        public string userTime { get; set; }
        public string mibao { get; set; }
        public string Input_Date { get; set; }
        public string xiajilist { get; set; }
        public string gongsi { get; set; }

    }

    public class ming_xi_info
    {
        public string Id { get; set; }
        public string Openid { get; set; }
        public string Cpid { get; set; }
        public string Cpjg { get; set; }
        public string Cplb { get; set; }
        public string Cpname { get; set; }
        public string Cpsj { get; set; }
        public string Cpsl { get; set; }
        public string Finduser { get; set; }
        public string Gongsi { get; set; }
        public string Mxtype { get; set; }
        public string Orderid { get; set; }
        public string Shijian { get; set; }
        public string sp_dm { get; set; }
        public string shou_h { get; set; }
        public string zh_name { get; set; }
        public string gs_name { get; set; } 
    }

    public class qi_chu_info
    {
        public string Id { get; set; }
        public string Openid { get; set; }
        public string Cpid { get; set; }
        public string Cpjg { get; set; }
        public string Cpjj { get; set; }
        public string Cplb { get; set; }
        public string Cpname { get; set; }
        public string Cpsj { get; set; }
        public string Cpsl { get; set; }
        public string Mxtype { get; set; }
        public string Shijian { get; set; }
        public string zh_name { get; set; }
        public string gs_name { get; set; } 
    }

    public class ku_cun {
        public string Name { get; set; }
        public string Shou_jia { get; set; }
        public string Jin_jia { get; set; }
        public string Lei_bie { get; set; }
        public string Mx_lb { get; set; }
        public string Shu_liang { get; set; }
        public string Jia_ge { get; set; }
        public string Ri_qi { get; set; }
        public string Gong_huo { get; set; }
        public string Shou_huo { get; set; }
        public string Dan_hao { get; set; }
        public string Tou_xiang { get; set; }
        public string Sp_dm { get; set; }
        public string Bei_zhu { get; set; }
        public string Id { get; set; }
        public string zh_name { get; set; }
        public string gs_name { get; set; } 
    }

    public class jxc_1_info
    {
        public string Sp_dm { get; set; }
        public string Name { get; set; }
        public string Lei_bie { get; set; }
        public string Cpsj { get; set; }
        public string Cpsl { get; set; }
        public string Cpje { get; set; }
    }

    public class jxc_2_info
    {

        
        public string Cpsj{ get; set; }
        public string Cpsl { get; set; }
        public string Cpje { get; set; }
    }

    public class jxc_3_info
    {


        public string Cpsj { get; set; }
        public string Cpsl { get; set; }
        public string Cpje { get; set; }
    }

    public class jxc_4_info
    {
        public string Cpjc { get; set; }
        public string Cpsj { get; set; }
        public string Cpje { get; set; }
        public string Cptx { get; set; }
    }

    public class jxc_z_info
    {
        public string ID { get; set; }
        public string Sp_dm { get; set; }
        public string Name { get; set; }
        public string Lei_bie { get; set; }
        public string Cpsj_1 { get; set; }
        public string Cpsl_1 { get; set; }
        public string Cpsj_2 { get; set; }
        public string Cpsl_2 { get; set; }
        public string Cpsj_3 { get; set; }
        public string Cpsl_3 { get; set; }
        public string Cpje_1{ get; set; }
        public string Cpje_2 { get; set; }
        public string Cpje_3 { get; set; }
        public string jc_jc { get; set; }
        public string jc_dj { get; set; }
        public string jc_je { get; set; }
        public string yl_tx { get; set; }
    }

    public class rc_ku_info
    {
        public string Ri_qi { get; set; }
        public string Gong_huo { get; set; }
        public string Orderid { get; set; }
        public string Sp_dm { get; set; }
        public string Name { get; set; }
        public string Lei_bie { get; set; }
        public string Shou_jia { get; set; }
        public string Shu_liang { get; set; }
        public string Shou_jia_2 { get; set; }
        public string Shu_liang_2{ get; set; }
       
    }

    public class zl_and_jc_info
    {
        public string sp_dm { get; set; }
        public string name { get; set; }
        public string lei_bie { get; set; }
        public string dan_wei { get; set; }
        public string shou_huo { get; set; }
        public string Gong_huo { get; set; }
        public string id { get; set; }
        public string zh_name { get; set; }
        public string gs_name { get; set; } 

    }

    public class yong_liao_set_info
    {
        public string cp_name { get; set; }
        public string yl_dm { get; set; }    
        public string yl_name { get; set; }
        public string yl_sl { get; set; }
        public string id { get; set; }
        public string yl_tx { get; set; }
        public string zh_name { get; set; }
        public string gs_name { get; set; } 
    }
    public class clCard_info
    {
        public string Order_id { get; set; }//=FItemID
        public string daima_gonghao { get; set; }
        public string mingcheng { get; set; }
        public string quanming { get; set; }
        public string xingbie { get; set; }
        public string minzu { get; set; }
        public string chushengriqi { get; set; }
        public string zhengjianleixing { get; set; }
        public string zhengjianhaoma { get; set; }
        public string jiatingzhuzhi { get; set; }
        public string zhengjianyouxiao { get; set; }
        public string jiguan { get; set; }
        public string shenheren { get; set; }
        public string fujian { get; set; }
        public string tupian { get; set; }
        public string CardType { get; set; }

        //PIC
        public string FTypeID { get; set; }
        public string FItemID { get; set; }
        //public string FFileName { get; set; }//=tupian
        public string FData { get; set; }
        public string FVersion { get; set; }
        public string FSaveMode { get; set; }
        public string FPage { get; set; }
        public string FEntryID { get; set; }


        public byte[] imagebytes { get; set; }

        //
        public string zhengjianyouxiaoStart { get; set; }
    }
    public class clt_Item_info
    {
        public string Order_id { get; set; }//=FItemID
        public string FItemID { get; set; }
        public string FItemClassID { get; set; }
        public string FExternID { get; set; }
        public string FNumber { get; set; }
        public string FParentID { get; set; }
        public string FLevel { get; set; }
        public string FDetail { get; set; }
        public string FName { get; set; }
        public string FUnUsed { get; set; }
        public string FBrNo { get; set; }
        public string FFullNumber { get; set; }
        public string FDiff { get; set; }
        public string FDeleted { get; set; }
        public string FShortNumber { get; set; }
        public string FFullName { get; set; }
        public string UUID { get; set; }
        public string FGRCommonID { get; set; }
        public string FSystemType { get; set; }
        public string FUseSign { get; set; }
        public string FChkUserID { get; set; }
        public string FAccessory { get; set; }
        public string FGrControl { get; set; }
        public DateTime FModifyTime { get; set; }
        public string FHavePicture { get; set; }
    }

    public class clt_POS_info
    {
        public string Order_id { get; set; }//=FItemID
        public string shangpinbianhao { get; set; }
        public string zhucemingcheng { get; set; }
        public string jingyingmingcheng { get; set; }
        public string suoshujigou { get; set; }
        public string jiaoyileixing { get; set; }
        public string jiaoyizhuangtai { get; set; }
        public string jiaoyijine { get; set; }
        public string jiaoyishouxufei { get; set; }
        public string jiaoyifujiashouxufei { get; set; }
        public string jiaoyishijian { get; set; }
        public string jiansuocankaohao { get; set; }
        public string Input_Date { get; set; }
        public string mark1 { get; set; }
        public string mark2 { get; set; }
        public string mark3 { get; set; }
        public string mark4 { get; set; }
        public string mark5 { get; set; }
     
    }

    public class userTable
    {
        public string _id { get; set; }
        public string AdminIS { get; set; }
        public string Btype { get; set; }
        public string Createdate { get; set; }
        public string _openid { get; set; }
        public string gongsi { get; set; }
        public string jigoudaima { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string mi_bao { get; set; }
    }

}
