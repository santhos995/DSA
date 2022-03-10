--Substring function used in orderby clause
select
    name
from
    students
where
    marks > 75
order by
    SUBSTR(name, -3),
    ID asc;

--CASE example
select
    case
        when A + B > C
        and A + C > B
        and B + C > A then case
            when A = B
            and B = C then 'Equilateral'
            when A = B
            or A = C then 'Isosceles'
            else 'Scalene'
        End
        else 'Not A Triangle'
    End
from
    triangles;

--https://www.hackerrank.com/challenges/full-score/problem
select
    h.hacker_id,
    h.name
from
    Hackers h,
    Difficulty d,
    Challenges c,
    Submissions s
where
    h.hacker_id = s.hacker_id
    and s.challenge_id = c.challenge_id
    and c.difficulty_level = d.difficulty_level
    and s.score = d.score
group by
    h.hacker_id,
    h.name
having
    count(h.name) > 1
order by
    count(h.name) desc,
    h.hacker_id;

--https://www.hackerrank.com/challenges/the-pads/problem?isFullScreen=true
select
    CONCAT(name, '(', SUBSTRING(occupation, 1, 1), ')') AS Name
from
    occupations
order by
    Name;

select
    CONCAT(
        'There are a total of ',
        count(occupation),
        ' ',
        lower(occupation),
        's.'
    ) as total
from
    occupations
group by
    occupation
order by
    total;

--https://www.hackerrank.com/challenges/binary-search-tree-1/problem
select
    case
        when P is null then CONCAT(N, ' Root')
        when N in (
            select
                distinct P
            from
                BST
        ) then CONCAT(N, ' Inner')
        else CONCAT(N, ' Leaf')
    end
from
    BST
order by
    N;

--https://www.hackerrank.com/challenges/weather-observation-station-20/problem?isFullScreen=true
--Oracle SQL -
select
    round(median(lat_n), 4)
from
    station;

--https://www.hackerrank.com/challenges/the-blunder/problem?isFullScreen=true
select
    ceil(avg(salary) - avg(replace(salary, "0", "")))
from
    employees;

--https://www.hackerrank.com/challenges/earnings-of-employees/problem
select
    max(salary * months),
    count(name)
from
    employee
group by
    (salary * months)
order by
    (salary * months) desc
limit
    1;

--https://www.hackerrank.com/challenges/the-report/problem?isFullScreen=true
select
    IF(Grade < 8, null, Name),
    Grade,
    Marks
from
    Students
    join Grades
where
    Marks between Min_Mark
    and Max_Mark
order by
    Grade desc,
    Name,
    Marks;

--https://www.hackerrank.com/challenges/weather-observation-station-19/problem?isFullScreen=false&h_r=next-challenge&h_v=zen
select
    round(
        SQRT(
            POWER(max(LAT_N) - min(LAT_N), 2) + POWER(max(LONG_W) - min(LONG_W), 2)
        ),
        4
    )
from
    station;

--Query Name, Friend_Name-- tables are students(Id, Name) and friends(Id, Friend_Id)
select
    a.name,
    b.name as FriendName
from
    students a,
    students b,
    friends f
where
    a.id = f.id
    and b.id = f.friend_id;