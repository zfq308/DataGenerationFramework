﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerationFramework.Core
{
    public enum Gender
    {
        Male,
        Female
    }

    public class CommonData
    {
        public string[] StreetSuffixesFull = { "street", "avenue", "drive", "boulevard", "road", "lane", "place", "circle", "terrace", "freeway" };
        public string[] StreetSuffixesAbbreviated = { "st", "ave", "dr", "blvd", "rd", "ln", "pl", "crl" };
        public string[] StreetDirectionFull = { "East", "North", "West", "South", "North East", "North West", "South East", "South West" };

        public const string Chinesechars = "一乙二十丁厂七卜八人入儿匕几九刁了刀力乃又三干于亏工土士才下寸大丈与万上小口山巾千乞川亿个夕久么勺凡丸及广亡门义之尸己已弓子卫也女刃飞习叉马乡丰王开井天夫元无云专丐扎艺木五支厅不犬太区历歹友尤匹车巨牙屯戈比互切瓦止少日中贝冈内水见午牛手气毛升夭长仁什片仆化仇币仍仅斤爪反介父从仑今凶分乏公仓月氏勿欠风丹匀乌勾凤六文方火为斗忆计订户认冗讥心尺引丑巴孔队办以允予邓劝双书幻玉刊未末示击打巧正扑扒功扔去甘世艾古节本术可丙左厉石右布夯龙平灭轧东卡北占凸卢业旧帅归旦目且叶甲申叮电号田由只叭史央兄叽叼叫叨另叹皿凹囚四生矢失乍禾丘付仗代仙们仪白仔他斥瓜乎丛令用甩印尔乐句匆册犯外处冬鸟务包饥主市立冯玄闪兰半汁汇头汉宁穴它讨写让礼训议必讯记永司尼民出辽奶奴召加皮边孕发圣对台矛纠母幼丝邦式迂刑邢动扛寺吉扣考托老巩圾执扩扫地场扬耳芋共芍芒亚芝朽朴机权过臣吏再协西压厌在百有存而页匠夸夺灰达列死成夹夷轨邪划迈毕至此贞师尘尖劣光当早吁吐吓虫曲团吕同吊吃因吸吗吆屿屹岁帆回岂则刚网肉年朱先丢廷舌竹迁乔迄伟传乒乓休伍伏优臼伐延仲件任伤价伦份华仰仿伙伪自伊血向似后行舟全会杀合兆企众爷伞创肌肋朵杂危旬旨旭负匈名各多凫争色壮冲妆冰庄庆亦刘齐交衣次产决亥充妄闭问闯羊并关米灯州汗污江汛池汤忙兴宇守宅字安讲讳军讶许讹论讼农讽设访诀寻那迅尽导异弛阱孙阵阳收阶阴防奸如妇好她妈戏羽观欢买红驮纤驯约级纪驰纫巡寿弄麦玖玛形进戒吞远违韧运扶抚坛技坏抠扰扼拒找批址扯走抄贡汞坝攻赤折抓扳抡扮抢孝坎均坞抑抛投坟坑抗坊抖护壳志块扭声把报拟却抒劫芙芜苇芽花芹芥芬苍芳严芦芯劳克芭苏杆杠杜材村杖杏杉巫极李杨杈求甫匣更束豆两丽医辰励否还歼来连轩步卤坚肖旱盯呈时吴助县里呆吱吠呕园旷围呀吨足邮男困吵串员呐听吟吩呛吻吹呜吭吧邑吼囤别吮岖岗帐财针钉牡告我乱利秃秀私每兵估体何佑但伸佃作伯伶佣低你住位伴身皂伺佛囱近彻役返余希坐谷妥含邻岔肝肛肚肘肠龟甸免狂犹狈角删鸠条彤卵灸岛刨迎饭饮系言冻状亩况床库庇疗吝应这冷庐序辛弃冶忘闰闲间闷判兑灶灿灼弟汪沐沛汰沥沙汽沃沦汹泛沧没沟沪沈沉怀忧忱快完宋宏牢究穷灾良证启评补初社诅识诈诉罕诊词译君灵即层屁尿尾迟局改张忌际陆阿陈阻附坠妓妙妖姊妨妒努忍劲鸡纬驱纯纱纲纳驳纵纷纸纹纺驴纽奉玩环武青责现玫表规抹卦坷坯拓拢拔坪拣坦担坤押抽拐拖者拍顶拆拥抵拘势抱拄垃拉拦幸拌拧拂拙招坡披拨择抬拇拗其取茉苦昔苛若茂苹苫苗英苟苞范直茁茄茎苔茅枉林枝杯枢柜枚析板松枪枫构杭杰述枕丧或画卧事刺枣雨卖郁矾矿码厕奈奔奇奄奋态欧殴垄妻轰顷转斩轮软到非叔歧肯齿些卓虎虏肾贤尚旺具昙味果昆国哎咕昌呵畅明易咙昂典固忠呻咒咐呼鸣咆咏呢咖岸岩帖罗帜帕岭凯败账贩贬购贮图钓制知氛垂牧物乖刮秆和季委秉佳侍岳供使例侠侥版侄侦侣侧凭侨佩货侈依卑的迫质欣征往爬彼径所舍金刽刹命肴斧爸采觅受乳贪念贫忿瓮肤肺肢肿胀朋股肮肪肥服胁周昏鱼兔狐忽狗狞备饰饱饲变京享庞店夜庙府底疟疙疚剂卒郊废净盲放刻育氓闸闹郑券卷单炬炒炊炕炎炉沫浅法泄沽河沾泪沮油泊沿泡注泣泞泻泌泳泥沸沼波泼泽治怔怯怖性怕怜怪学宝宗定宠宜审宙官空帘宛实试郎诗肩房诚衬衫衩视祈话诞诡询该详建肃录隶帚屉居届刷屈弧弥弦承孟陋陌孤陕降函限妹姑姐姓始姆虱驾叁参艰线练组绅细驶织驹终驻绊驼绍绎经贯契贰奏春帮玷珍玲珊玻毒型拭挂封持拷拱项垮挎城挟挠政赴赵挡挺括垢拴拾挑垛指垫挣挤拼挖按挥挪拯某甚荆茸革茬荐巷荚带草茧茵茴荞茶荠荒茫荡荣荤荧故胡荔南药标栈柑枯柄栋相查柏栅柳柱柿栏柠枷树勃要柬咸威歪研砖厘厚砌砂泵砚砍面耐耍牵鸥残殃轴轻鸦皆韭背战点虐临览竖省削尝昧盹是盼眨哄哑显冒映星昨咧昵昭畏趴胃贵界虹虾蚁思蚂盅虽品咽骂勋哗咱响哈哆咬咳咪哪哟炭峡罚贱贴骨幽钙钝钞钟钢钠钥钦钧钩钮卸缸拜看矩毡氢怎牲选适秕秒香种秋科重复竿段便俩贷顺修俏保促俄俐侮俭俗俘信皇泉鬼侵侯追俊盾待徊衍律很须叙剑逃食盆胚胧胆胜胞胖脉胎勉狭狮独狰狡狱狠贸怨急饵饶蚀饺饼峦弯将奖哀亭亮度奕迹庭疮疯疫疤咨姿亲音飒帝施闺闻闽阀阁差养美姜叛送类迷籽娄前首逆总炼炸烁炮炫烂剃洼洁洪洒柒浇浊洞测洗活涎派洽染洛济洋洲浑浓津恃恒恢恍恬恤恰恼恨举觉宣宦室宫宪突穿窃客诫冠诬语扁袄祖神祝祠误诱诲说诵垦退既屋昼屏屎费陡逊眉孩陨除险院娃姥姨姻娇姚娜怒架贺盈勇怠蚤柔垒绑绒结绕骄绘给骆络绝绞骇统耕耘耗耙艳泰秦珠班素匿蚕顽盏匪捞栽捕埂捂振载赶起盐捎捍捏埋捉捆捐损袁捌都哲逝捡挫换挽挚热恐捣壶捅埃挨耻耿耽聂荸恭莽莱莲莫莉荷获晋恶莹莺真框梆桂栖档桐株桥桦栓桃桅格桩校核样根索哥速逗栗贾酌配翅辱唇夏砸砰砾础破原套逐烈殊殉顾轿较顿毙致柴桌虑监紧党逞晒眠晓哮唠鸭晃哺晌剔晕蚌蚜畔蚣蚊蚪蚓哨哩圃哭恩鸯唤唁哼唧啊唉唆罢峭峰圆峻贼贿赂赃钱钳钻钾铁铃铅铆缺氧氨特牺造乘敌秫秤租积秧秩称秘透笔笑笋笆债借值倚俺倾倒倘俱倡候赁俯倍倦健臭射躬息倔徒徐殷舰舱般航途拿耸爹舀爱豺豹颁颂翁胯胰脆脂胸胳脏脐胶脑脓逛狸狼卿逢鸵留鸳皱饿馁凌凄恋桨浆衰衷高郭席准座症病疾斋疹疼疲脊效离紊唐瓷资凉站剖竞部旁旅畜阅羞羔瓶拳粉料益兼烤烘烦烧烛烟烙递涛浙涝浦酒涉消涡浩海涂浴浮涣涤流润涧涕浪浸涨烫涩涌悟悄悍悔悯悦害宽家宵宴宾窍窄容宰案请朗诸诺读扇诽袜袒袖袍被祥课谁调冤谅谆谈谊剥恳展剧屑弱陵祟陶陷陪娱恕娩娘通能难预桑绢绣验继骏球琐理麸琉琅捧堵措描域捺掩捷排掉捶赦推堆埠掀授捻教掏掐掠掂掖培接掷掸控探据掘掺职基勘聊娶著菱勒黄菲萌萝菌萎菜萄菊菩萍菠萤营乾萧萨菇械彬梦梗梧梢梅检梳梯桶梭救曹副票酝酗厢戚硅硕奢盔爽聋袭盛匾雪辅辆颅虚彪雀堂常眶匙晤晨睁眯眼悬野啦曼晦冕晚啄啡畦距趾啃跃略蛆蚯蛉蛀蛇唬累唱患啰唾唯啤啥啸崖崎崭逻崔崩崇婴赊圈铐铛铝铜铡铣铭铲银矫甜秸梨犁秽移笨笼笛笙符第笤敏做袋悠偿偶偎傀偷您售停偏躯兜假衅徘徙得衔盘舶船舷舵斜盒鸽敛悉欲彩领翎脚脖脯脸脱象够逸猜猪猎猫凰猖猛祭馅馆凑减毫烹庶麻庵痊痒痕廊康庸鹿盗章竟商族旋望率阎阐着盖眷粘粗粒断剪兽焊焕清添鸿淋涯淹渠渐淑淌混淮淆渊淫渔淘淳液淤淡淀深涮涵婆梁渗情惜惭悼惧惕惊惦悴惋惨惯寇寄寂宿窒窑密谋谍谎谐裆袱祷祸谒谓谚谜逮敢尉屠弹堕随蛋隅隆隐婚婶婉颇颈绩绪续骑绰绳维绵绷绸综绽绿缀巢琴琳琢琼斑替揍款堪塔搭堰揩越趁趋超揽堤提揖博揭喜彭揣插揪搜煮援搀裁搁搓搂搅壹握搔揉斯期欺联葫散惹葬募葛董葡敬葱蒋蒂落韩朝辜葵棒棱棋椰植森焚椅椒棵棍椎棉棚棕棺榔椭惠惑逼粟棘酣酥厨厦硬硝确硫雁殖裂雄颊雳暂雅翘辈悲紫凿辉敞棠赏掌晴暑最晰量鼎喷喳晶喇遇喊遏晾景畴践跋跌跑跛遗蛙蛔蛛蜓蜒蛤喝鹃喂喘喉喻啼喧嵌幅帽赋赌赎赐赔黑铸铺链销锁锄锅锈锉锋锌锐甥掰短智氮毯氯鹅剩稍程稀黍税筐等筑策筛筒筏答筋筝傲傅牍牌堡集焦傍储粤奥街惩御循艇舒逾番释禽腊腌脾腋腔腕鲁猩猬猾猴惫然馋装蛮就敦痘痢痪痛童竣阔善翔羡普粪尊奠道遂曾焰焙港滞湖湘渣渤渺湿温渴溃溅滑湃湾渡游滋溉愤慌惰愕惶愧愉慨割寒富寓窜窝窖窗窘遍雇裕裤裙谢谣谤谦犀属屡强粥疏隔隙隘媒絮嫂媚婿登缅缆缎缓缔缕骗编骚缘瑟鹉瑞瑰魂肆摄摸填搏塌鼓摆携搬摇搞塘搪摊聘斟蒜勤靴靶鹊蓝墓幕蓖蓬蒿蓄蒲蓉蒙蒸献楔椿禁楚楷榄想楞槐榆楼概楣赖酪酬感碍碘碑硼碉碎碰碗碌雷零雾雹辐辑输督频龄鉴睛睹睦瞄睡睬嗜鄙嗦愚暖盟歇暗暇照畸跨跷跳跺跪路跟遣蜈蜗蛾蜂蜕蛹嗅嗡嗤嗓署置罪罩蜀幌错锚锡锣锤锥锦锨锭键锯锰矮辞稚稠颓愁筹签简筷毁舅鼠催傻像躲魁衙微愈遥腻腰腥腮腹腺鹏腾腿肄猿颖触解煞雏馍馏酱禀痹廓痴痰廉靖新韵意誊粮数煎塑慈煤煌满漠源滤滥滔溪溜漓滚溢溯滨溶滓溺粱滩慎誉塞寞窥窟寝谨褂裸福谬群殿辟障媳嫉嫌嫁叠缚缝缠缤剿静碧璃赘熬墙嘉摧赫截誓境摘摔撇聚蔫慕暮摹蔓蔑蔗蔽蔼熙蔚兢榛模榴榜榨榕歌遭酵酷酿酸碟碴碱碳磁愿需辕辖雌裳颗墅嗽嘁踊蜻蜡蝇蜘蝉嘀幔赚锹锻镀舞舔稳熏箍箕算箩管箫舆僚僧鼻魄貌膜膊膀鲜疑孵馒裹敲豪膏遮腐瘩瘟瘦辣彰竭端旗精粹歉弊熄熔漆漱漂漫滴漩漾演漏慢慷寨赛寡察蜜寥谭褐褪谱隧嫩嫡翠熊凳骡缨缩慧撵撕撒撩趣趟撑撮撬播擒墩撞撤增撰聪鞋鞍蕉蕊蔬蕴横槽樱樊橡樟橄敷豌飘醋醇醉磕磅碾震霉瞒题暴瞎嘶嘲嘹影踢踏踩踪蝶蝴蝠蝎蝌蝗蝙嘿嘱幢墨镊镇镐靠稽稻黎稿稼箱篓箭篇僵躺僻德艘膝膘膛鲤鲫熟摩褒瘪瘤瘫凛颜毅糊遵憋潜澎潮潭潦澳潘澈澜澄懂憔懊憎额翩褥谴鹤憨慰劈履嬉豫缭撼擂操擅燕蕾薯薛薇擎薪薄颠翰噩橱橙橘整融瓢醒磺霍霎辙冀餐嘴踱蹄蹂蟆螃螟器噪鹦赠默黔镜赞穆篮篡篷篙篱儒邀衡膨膳雕鲸磨瘾瘸凝辨辩糙糖糕燎燃濒澡激懒憾懈窿壁避缰缴戴壕擦鞠藏藐檬檐檩檀礁磷霜霞瞭瞧瞬瞳瞪曙蹋蹈螺蟋蟀嚎赡镣穗魏簇繁儡徽爵朦臊鳄糜癌辫赢糟糠燥懦豁臀臂翼骤藕鞭藤覆瞻蹦嚣镰翻鳍鹰癞瀑襟璧戳攒孽警蘑藻攀蹲蹭蹬簸簿蟹颤靡癣瓣羹鳖爆疆鬓壤攘耀躁蠕嚼嚷巍籍鳞魔糯灌譬蠢霸露霹躏髓蘸囊镶瓤罐矗";
    }
}
