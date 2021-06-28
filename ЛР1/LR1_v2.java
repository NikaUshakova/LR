// 2.Составить программу, которая формирует одномерный массив
// из n случайных чисел. Получить из него два новых массива: один из
// четных чисел, а другой из нечетных. Значение n меняется в пределах
// от 10 до 50 миллионов.

import java.util.Random;
import java.util.ArrayList;

public class LR1_v2 {
    public static void main(String[] args){
        // System.out.println("Введите кол-во чисел от 10 000 000 до 50 000 000: ");
        // Scanner input = new Scanner(System.in);
        // n = input.nextInt();
          
        array(10000000);
        array(20000000);
        array(30000000);
        array(40000000);
        array(50000000);
    }

    public static void array(int n){
        long startTime = 0;
        long endTime = 0;

        int mas[] = new int[n];
        Random rand = new Random();
        for(int i = 0; i < mas.length; i++){
            mas[i] = rand.nextInt(50);
        }

        ArrayList<Integer> chetList = new ArrayList<Integer>();
        ArrayList<Integer> nechetList = new ArrayList<Integer>();

        startTime = System.currentTimeMillis();
//start algorithm
        for(int i = 0; i < mas.length; i++){
            if (mas[i] % 2 == 0){
                chetList.add(mas[i]);
            }
            else{
                nechetList.add(mas[i]);
            }
        } 
//end algorithm  
        endTime = System.currentTimeMillis();

        int[] chetMas = new int[chetList.size()];       
        int[] nechetMas = new int[nechetList.size()];

        for (int i = 0; i < chetMas.length; i++){
            chetMas[i] = chetList.get(i);
        }
        for (int i = 0; i < nechetMas.length; i++){
            nechetMas[i] = nechetList.get(i);
        }
        System.out.println("Затраченное время (в миллисекундах) на исходный массив из " + n + " элементов: "  + (endTime - startTime));
    }
    
}
