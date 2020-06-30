using System;
namespace MyProject.Entities
{     
        
           public class ChargeStationController                   
           {      
                /// <summary>
                /// 
                /// </summary>
                 public String  ID { get; set; }                                                                                           
                
                /// <summary>
                /// 
                /// </summary>
                 public String  Code { get; set; }                                                                                           
                
                /// <summary>
                /// 
                /// </summary>
                 public String  ControlAddress { get; set; }                                                                                           
                
                /// <summary>
                /// 
                /// </summary>
                 public String  StationID { get; set; }                                                                                           
                       
           }                  
             
           public class TestCol                   
           {      
                /// <summary>
                /// 
                /// </summary>
                 public Int64?  ID { get; set; }                                                                                           
                
                /// <summary>
                /// 姓名
                /// </summary>
                 public String  Name { get; set; }                                                                                           
                
                /// <summary>
                /// 
                /// </summary>
                 public DateTime?  DateTime { get; set; }                                                                                           
                
                /// <summary>
                /// 
                /// </summary>
                 public Byte[]  Image { get; set; }                                                                                           
                       
           }                  
             
           public class __EFMigrationsHistory                   
           {      
                /// <summary>
                /// 
                /// </summary>
                 public String  MigrationId { get; set; }                                                                                           
                
                /// <summary>
                /// 
                /// </summary>
                 public String  ProductVersion { get; set; }                                                                                           
                       
           }                  
             
           public class ChargeStation                   
           {      
                /// <summary>
                /// 主键ID
                /// </summary>
                 public String  ID { get; set; }                                                                                           
                
                /// <summary>
                /// 编码
                /// </summary>
                 public String  Code { get; set; }                                                                                           
                
                /// <summary>
                /// 名称
                /// </summary>
                 public String  Name { get; set; }                                                                                           
                
                /// <summary>
                /// 
                /// </summary>
                 public Int64  MaintainTel { get; set; }                                                                                           
                       
           }                  
                           
}