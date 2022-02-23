//Substring function used in orderby clause
select name from students where marks >75 order by SUBSTR(name, -3), ID asc; 

//CASE example
select case
    when A+B>C and A+C>B and B+C>A then
     case
        when A = B and B = C then 'Equilateral'
        when A = B or A = C then 'Isosceles'
        else 'Scalene'
     End
    else 'Not A Triangle'
    End 
    from triangles;