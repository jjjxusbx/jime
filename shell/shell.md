### shell 编程

#### shell 环境

```
（/usr/bin/sh 或/bin/sh）
（/bin/bash）
（/usr/bin/csh）
（/usr/bin/ksh）
Root（/sbin/sh）


#! /bin/bash
echo "hello world"

chmod +x ./test.sh #使脚本具有执行权限
./test.sh #执行脚本
```

### 变量

#### 定义变量

your\*name="f4uit"

### 使用变量

#### 变量名的命名规则

'''
只包含字母、数字和下划线： 变量名可以包含字母（大小写敏感）、数字和下划线 \*，不能包含其他特殊字符。
不能以数字开头： 变量名不能以数字开头，但可以包含数字。
避免使用 Shell 关键字： 不要使用 Shell 的关键字（例如
if、then、else、fi、for、while 等）作为变量名，以免
引起混淆。
使用大写字母表示常量： 习惯上，常量的变量名通常使
用大写字母，例如 PI=3.14。
避免使用特殊符号：
避免使用空格： 变量名中不应该包含空格，因为空格通
常用于分隔命令和参数。
'''
your_name="f4uit"
echo $your_name

for skill in im Coffe Action Java; do
echo "I am good at ${skill}Script"
done

### 重新赋值

your_name="dashaZi"
echo ${your_name}
your_name="dashazi"
echo ${your_name}

### 只读变量

#!/bin/bash
my_name="dashaZi"
readonly my_name
my_name="dashazi"
echo ${my_name}

### 删除变量

#### 代码运行后将不会有任何输出

#!/bin/bash
my_name="dashaZi"
nset my_name
echo ${my_name}

### 变量类型

#### 字符串类型

my_name_1='dashaZi'
my_name_2="dashazi"

#### 整数类型

declare -i my_age=18 #-i 转换为整数

#### 数组

关联数组适用于需要字符串键的场景；索引数组适用于需要按顺序访问元素的场景

declare -a 用于声明一个索引数组

#### 关联数组

declare -A my_array
my_array["name"]="dashaZi"
my_array["age"]=18

#### 函数封装

#### 含参函数

add_numbers() {
sum=$(($1 + $2))
echo "Hello $1 and $2 is dashazi"
}

#### 函数调用

#!/bin/bash
add_numbers 2 3
可以存在 retur 返回值
$()与反引号都可以用于获取指令结果，但建议用$(),他可以嵌套使用
条件判断
if [ condition ]; then
commands # 条件为真时执行的命令
fi #关键字

### 判断一个变量是否大于 10

if [ $num -gt 10 ]; then
echo "$num is greater than 10"
fi

### 判断一个数是奇数还是偶数

#!/bin/bash
num=7
if [ $((num % 2)) -eq 0 ]; then
echo "$num is even"
else
echo "$num is odd"
fi

### if - elif - else

#!/bin/bash
score=85
if [ $score -ge 90 ]; then
echo "A"
elif [ $score -ge 80 ]; then
echo "B"
elif [ $score -ge 70 ]; then
echo "C"
elif [ $score -ge 60 ]; then
echo "D"
else
echo "F"
fi

#### 条件符号

-lt：小于。
-le：小于等于。
-eq：等于。
-ne：不等于。
-ge：大于等于。
-gt：大于

#### 循环结构

遍历一个数字列表并打印每个数字
for number in 1 2 3 4 5; do
echo $number
done
number 会依次取 1、2、3、4、5，并在每次循环中通过 echo 命令输出。
遍历数组
fruits=("apple" "banana" "cherry")
for fruit in "${fruits[@]}"; do
echo $fruit
done

使用命令生成列表
for file in $(ls); do
echo $file
done

count 初始值为 1，每次循环判断 count 是否小于等于 5，如果是则打印 count 的值，然后将 count 的值加 1。当 count 大于 5 时，循环结束。
count=1
while [ $count -le 5 ]; do
echo $count
    count=$((count + 1))
done
逐行读取一个文件的内容
while read line; do
echo $line
done < file.txt

until 循环与 while 循环相反，它在条件为假时持续执行命令块，直到条件变为真
计算从 1 加到某个数，直到总和大于等于 10
sum 为 0，num 为 1，每次循环将 num 累加到 sum 中，并将 num 加 1，直到 sum 大于等于 10，循环结束后输出 sum 的值。
sum=0
num=1
until [ $sum -ge 10 ]; do
sum=$((sum + num))
num=$((num + 1))
done
echo $sum
break 跳出循环
for i in 1 2 3 4 5; do
if [ $i -eq 3 ]; then
break
fi
echo $i
done
continue 跳过当前循环的剩余部分，直接进入下一次循环
for i in 1 2 3 4 5; do
if [ $i -eq 3 ]; then
continue
fi
echo $i
done

#### CASE-ESAC
