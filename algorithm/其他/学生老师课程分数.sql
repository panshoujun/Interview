--1. 查询" 01 "课程比" 02 "课程成绩高的学生的信息及课程分数
select * from sc t1,sc t2 where t1.c#=01 and t2.C#=02 and t1.s#=t2.S# and t1.score>t2.score
--1.1 查询同时学了存在" 01 "课程和" 02 "课程的情况
select * from Student s,sc t1,sc t2 where s.S#=t1.S# and s.S#=t2.S# and t1.C#=01 and t2.C#=02

select * from Student s inner join  (select * from SC where C#='01')A on s.S#=a.S#
inner join (select * from SC where C#='02')B on s.S#=B.S#
--2. 查询平均成绩大于等于 60 分的同学的学生编号和学生姓名和平均成绩
select s.S#,s.Sname,AVG(sc.score)  from Student s inner join SC sc on s.S#=sc.S#
 group by s.S#,s.Sname having AVG(sc.score)>60
 -- 3. 查询在 SC 表存在成绩的学生信息
 select * from Student s where s.S# in (select distinct S# from SC)
 --4. 查询所有同学的学生编号、学生姓名、选课总数、所有课程的总成绩(没成绩的显示为 null )
 select s.*,(select COUNT(*) from SC where SC.S#=s.S#),(select sum(SC.score) from SC 
 where SC.S#=s.S#) from Student s;
 
 select s.S#,s.Sname,count(sc.score),sum(sc.score)  from Student s 
 left join SC sc on s.S#=sc.S# group by s.S#,s.Sname order by s.S# 
 
 --5. 查询「李」姓老师的数量 
 select * from Teacher t where t.Tname like '李%'
--6. 查询学过「张三」老师授课的同学的信息 
 select * from Student s inner join SC sc on s.S#=sc.S# inner join 
 Course c on sc.C#=c.C# inner join Teacher t on c.T#=t.T# where t.Tname='张三'
 --7. 查询没有学全所有课程的同学的信息
 select * from Student s where s.S# in(select SC.S# from SC 
 group by SC.S# having COUNT(SC.S#)= (select COUNT(*) from Course))
 
 select s.S#,s.Sname from Student s inner join SC sc on s.S#=sc.S#
 group by s.S#,s.Sname having COUNT(s.S#)= (select COUNT(*) from Course)
 --8. 查询至少有一门课与学号为" 01 "的同学所学相同的同学的信息
 select * from Student s where s.S# in(
 select distinct S# from SC where C# in(
 select C# from SC where S#=01))
 
 select distinct s.* from Student s inner join SC t1 on s.S#=t1.S# 
 inner join SC t2 on t1.C#=t2.C#  where t2.S#=01
 --9. 查询和" 01 "号的同学学习的课程完全相同的其他同学的信息 
select * from Student s where s.S# in(select t1.S# from SC t1 where t1.C# in 
(select C# from SC t2 where t2.S#=01) group by t1.S# having COUNT(t1.S#) = 
(select COUNT(C#) from SC t2 where t2.S#=01)) and s.S#<>01
--10. 查询没学过「张三」老师讲授的任一门课程的学生姓名
select * from Student where S# not in (
select distinct S# from SC where C# in (
select C# from Course where T# in(select T# from Teacher where tname='张三')))
--11. 查询两门及其以上不及格课程的同学的学号，姓名及其平均成绩
select * from Student s where S# in(
select S# from SC where score<60 group by S# having COUNT(S#)>1)

select s.S#,s.Sname,AVG(score) from Student s inner join SC sc on s.S#=sc.S# 
where sc.score<60 group by s.S#,s.Sname having COUNT(s.S#)>1
--12. 检索" 01 "课程分数小于 60，按分数降序排列的学生信息
select * from Student s inner join SC sc on s.S#=sc.S#
where sc.C#=01 and sc.score<60 order by sc.score desc
--13. 按平均成绩从高到低显示所有学生的所有课程的成绩以及平均成绩
select S#,AVG(score),max(case C# when 01 then score else 0 end)
,max(case C# when 02 then score else 0 end),max(case C# when 03 then score 
else 0 end) from SC group by S# order by AVG(score) desc;

--14. 查询各科成绩最高分、最低分和平均分：
--以如下形式显示：课程 ID，课程 name，最高分，最低分，平均分，及格率，中等率，优良率，优秀率
select c.C#,c.Cname,MAX(score) max,MIN(score) min,AVG(score) avg
,convert(decimal(5,2),sum(case when score>=60 then 1 else 0 end)*1.00/COUNT(score))*100 及格率
,convert(decimal(5,2),sum(case when score>=70 and score<80 then 1 else 0 end)*1.00/COUNT(score))*100 中等率
,convert(decimal(5,2),sum(case when score>=80 and score<90 then 1 else 0 end)*1.00/COUNT(score))*100 优良率
,convert(decimal(5,2),sum(case when score>=90  then 1 else 0 end)*1.00/COUNT(score))*100 优秀率
from SC sc inner join Course c on sc.C#=c.C# group by c.C#,c.Cname

--15. 按各科成绩进行排序，并显示排名， Score 重复时保留名次空缺
select *,RANK() over(order by score desc) from SC;
--15.1 按各科成绩进行排序，并显示排名， Score 重复时合并名次
select *,dense_rank() over(order by score desc) from SC;
--16.  查询学生的总成绩，并进行排名，总分重复时保留名次空缺
select *,RANK() over(order by sumscore desc) from (
select S#,SUM(score) sumscore from SC group by S# ) T
--16.1 查询学生的总成绩，并进行排名，总分重复时不保留名次空缺
select *,dense_RANK() over(order by sumscore desc) from (
select S#,SUM(score) sumscore from SC group by S# ) T

--17. 统计各科成绩各分数段人数：课程编号，课程名称，[100-85]，[85-70]，[70-60]，[60-0] 及所占百分比
--与第14雷同

--18. 查询各科成绩前三名的记录
select * from (select top 3 * from SC where C#=01 order by score desc) a union
select * from (select top 3 * from SC where C#=02 order by score desc) b union
select * from (select top 3 * from SC where C#=03 order by score desc) c 
order by C# ,a.score desc

select a.S#,a.C#,a.score from SC a 
left join SC b on a.C#=b.C# and a.score<b.score
group by a.S#,a.C#,a.score
having COUNT(b.S#)<3
order by a.C#,a.score desc

select * from SC a where (select COUNT(*)from SC where C#=a.C# and score>a.score)<3
order by a.C#,a.score desc
--19. 查询每门课程被选修的学生数 
select C#,COUNT(C#) from SC group by C#
--20. 查询出只选修两门课程的学生学号和姓名 
select S#,COUNT(S#) from SC group by S# having COUNT(S#)=2
select s.S#,s.Sname from Student s inner join SC sc on s.S#=sc.S# 
group by s.S#,s.Sname having COUNT(s.S#)=2
--21. 查询男生、女生人数
select s.Ssex,COUNT(s.Ssex) from Student s group by s.Ssex
--22. 查询名字中含有「风」字的学生信息
select * from Student s where s.Sname like '%风%'
--23. 查询同名同性学生名单，并统计同名人数
select s.Sname,COUNT(s.Sname) from Student s group by s.Sname having COUNT(s.Sname)>1
--24. 查询 1990 年出生的学生名单
select * from Student s where s.Sage>='1990-01-01' and s.Sage<'1991-01-01'
select * from Student where YEAR(Sage)=1990
--25. 查询每门课程的平均成绩结果按平均成绩降序排列平均成绩相同时按课程编号升序排列
select C#,AVG(score) from SC group by C# order by AVG(score) desc,C# asc
--26. 查询平均成绩大于等于 85 的所有学生的学号、姓名和平均成绩 
select s.S#,s.Sname,AVG(sc.score) from Student s inner join SC sc on s.S#=sc.S# 
group by s.S#,s.Sname having AVG(sc.score)>85
--27. 查询课程名称为「数学」，且分数低于 60 的学生姓名和分数
select * from Student s inner join SC sc on s.S#=sc.S# inner join Course c 
on sc.C#=c.C# where c.Cname='数学' and sc.score<60
--28. 查询所有学生的课程及分数情况（存在学生没成绩，没选课的情况）
select s.S#,s.Sname
,MAX( case c.Cname when '语文' then sc.score else 0 end) 语文
,MAX(case c.Cname when '数学' then sc.score else 0 end) 数学
,MAX(case c.Cname when '英语' then sc.score else 0 end) 英语
 from Student s inner join  SC  sc on s.S#=sc.S# inner join 
 Course c on sc.C#=c.C# group by s.S#,s.Sname

 select *  from(select  sc.SCORE,sc.C#,s.* from Student s inner join  
 SC  sc on s.S#=sc.S# inner join Course c on sc.C#=c.C#) sc 
 pivot(max(sc.Score) for sc.C# in ([01],[02],[03])) t
 
select * from Student s left join Course c on 1=1 
left join SC sc on c.C#=sc.C# and s.S#=sc.S#
--29. 查询任何一门课程成绩在 70 分以上的姓名、课程名称和分数
select * from Student s inner join SC sc on s.S#=sc.S# inner join 
Course c on sc.C#=c.C# where sc.score>70
-- 30. 查询不及格的课程
select * from SC where score<60
--31. 查询课程编号为01且课程成绩在80分以上的学生的学号和姓名
select * from Student s inner join SC sc on s.S#=sc.S# 
where sc.C#=01 and sc.score>80
--32. 求每门课程的学生人数 
select SC.C#,COUNT(SC.C#) from SC group by SC.C#
--33.成绩不重复,查询选修「张三」老师所授课程的学生中，成绩最高的学生信息及其成绩
select top 1 * from Student s inner join SC sc on s.S#=sc.S# inner join 
Course c on sc.C#=c.C# inner join Teacher t on c.T#=t.T# where 
t.Tname='张三' order by sc.score desc
--34.成绩有重复的情况下,查询选修张三老师所授课程的学生中，成绩最高的学生信息及其成绩
select * from (
select  s.*,sc.C#,sc.score ,(DENSE_RANK() over(order by sc.score desc)) r from Student s 
inner join SC sc on s.S#=sc.S# inner join Course c on sc.C#=c.C# inner join 
Teacher t on c.T#=t.T# where t.Tname='张三' ) ff where ff.r=1

select  * from Student s inner join SC sc on s.S#=sc.S# inner join 
Course c on sc.C#=c.C# inner join Teacher t on c.T#=t.T# where 
t.Tname='张三' and sc.score=(select max(sc.score) from SC sc  inner join 
Course c on sc.C#=c.C# inner join Teacher t on c.T#=t.T# where 
t.Tname='张三') order by sc.score desc

select *from(select *,DENSE_RANK()over (order by score desc)A 
from SC 
where C#=(select C# from Course where T#=(select T# from Teacher where Tname='张三')))B
where B.A=1
--35. 查询不同课程成绩相同的学生的学生编号、课程编号、学生成绩 
select C.S#,max(C.C#)C#,max(C.score)score from SC C 
left join(select S#,avg(score)A from SC group by S#)B 
on C.S#=B.S# where C.score=B.A group by C.S#
having COUNT(0)=(select COUNT(0)from SC where S#=C.S#)
--36. 查询每门功成绩最好的前两名
select C#,SCORE from (select top 2 * from SC where C# = 01 order by SCORE desc) a  union all
select C#,SCORE from (select top 2 * from SC where C# = 02 order by SCORE desc) b order by C#

select * from
(select *,ROW_NUMBER()over(partition by C# order by score desc)rank from SC)B
where B.rank<3
--37. 统计每门课程的学生选修人数（超过 5 人的课程才统计）。
select sc.C#,COUNT(sc.C#) from SC sc group by sc.C# having count(sc.C#)>5
-- 38. 检索至少选修两门课程的学生学号 
select sc.S#,COUNT(sc.S#) from SC sc group by sc.S# having COUNT(sc.S#)>1
--39. 查询选修了全部课程的学生信息
select s.S#,s.Sname from Student s inner join  SC sc on s.S#=sc.S# group by s.S#,s.Sname
 having COUNT(sc.S#)=(select COUNT(*) from Course)
--40查询各学生的年龄，只按年份来算
 select YEAR(s.Sage),COUNT(YEAR(s.Sage)) from Student s  group by YEAR(s.Sage)
 
 select S#,datediff(yy,Sage,GETDATE())年龄 from Student
--41. 按照出生日期来算，当前月日 < 出生年月的月日则，年龄减一
select *,(case when convert(int,'1'+substring(CONVERT(varchar(10),Sage,112),5,8))
<convert(int,'1'+substring(CONVERT(varchar(10),GETDATE(),112/*112是将格式转化为yymmdd*/),5,8)) 
then datediff(yy,Sage,GETDATE()) else datediff(yy,Sage,GETDATE())-1 
end)age from Student
--42. 查询本周过生日的学生
select *,(case when datename(wk,convert(datetime,(convert(varchar(10),year(GETDATE()))
+substring(convert(varchar(10),Sage,112),5,8))))=DATENAME(WK,GETDATE()) 
then 1 else 0 end)生日提醒
from Student
--43. 查询下周过生日的学生
select *,(case when datename(wk,convert(datetime,(convert(varchar(10),year(GETDATE()))+
substring(convert(varchar(10),Sage,112),5,8))))=DATENAME(WK,GETDATE())+1 
then 1 else 0 end)生日提醒
from Student
--44. 查询本月过生日的学生
select *,MONTH(s.Sage),GETDATE() from Student s where MONTH(s.Sage)=MONTH(GETDATE())

select *,(case when month(convert(datetime,(convert(varchar(10),year(GETDATE()))+
substring(convert(varchar(10),Sage,112),5,8))))=month(GETDATE())
then 1 else 0 end)生日提醒 from Student
--45. 查询下月过生日的学生
select *,MONTH(s.Sage),GETDATE() from Student s where MONTH(s.Sage)=MONTH(GETDATE())+1

select *,(case when month(convert(datetime,(convert(varchar(10),year(GETDATE()))
+substring(convert(varchar(10),Sage,112),5,8))))=month(GETDATE())+1
then 1 else 0 end)生日提醒
from Student

