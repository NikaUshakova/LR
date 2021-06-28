// 10.Составить две программы, которые реализуют алгоритмы ускоренной cортировки «пузырьком» и шейкером. 
// Исходные данные задавать с помощью датчика случайных чисел.

import java.util.Random;

class SortNumbers{
    public static void main(String[] args){
        int n=100000;
        int mas[] = new int[n];
        Random rand = new Random();
        for(int i = 0; i < mas.length; i++){
            mas[i] = rand.nextInt(30);
            //System.out.print(mas[i] + " ");
        } 
        
        sortBubble(mas);          
        sortSheiker(mas); 
    }

    public static void sortBubble(int[] mas){
        long startTime = 0;
        long endTime = 0;
        startTime = System.currentTimeMillis();
//start algorithm
        for (int i = mas.length-1; i > 0; i--){
            for (int j = 0; j < i; j++){
                if (mas[j] > mas[j+1]){
                    int temp = mas[j];
                    mas[j] = mas[j+1];
                    mas[j+1] = temp;
                }
            }
        }
//end algorithm
        endTime = System.currentTimeMillis();

        //  System.out.println("\nМассив, отсортированный по возврастанию с помощью алгоритма Пузырика:");
        // for(int i = 0; i < mas.length; i++){
        //     System.out.print(mas[i] + " ");
        // }
        System.out.println("\nПузырик: затраченное время (в миллисекундах) на исходный массив из " + mas.length + " элементов: "  + (endTime - startTime));
    }

    public static void sortSheiker(int[] mas){
        long startTime = 0;
        long endTime = 0;
        startTime = System.currentTimeMillis();

//start algorithm
        int left = 0;
        int right = mas.length - 1; 
        
        //слева направо
        // System.out.println(left + ", right: " + right);
            for (int i = left; i < right; i++){
                if (mas[i] > mas[i+1]){
                    int temp = mas[i];
                    mas[i] = mas[i+1];
                    mas[i+1] = temp;
                }                
                right--;                
            }
        //справа налево
        // System.out.println(left + ", right: " + right);
            for (int i = right; i > left; i--){
                if (mas[i-1] > mas[i]){
                    int temp = mas[i-1];
                    mas[i-1] = mas[i];
                    mas[i] = temp;
                }
                left++;
            }
//end algorithm
        endTime = System.currentTimeMillis();
                
        // System.out.println("\nМассив, отсортированный по возврастанию с помощью алгоритма Шейкера:");
        //         for (int i = 0; i < mas.length; i++){
        //     System.out.print(mas[i] + " ");
        // }
        System.out.println("\nШейкер: затраченное время (в миллисекундах) на исходный массив из " + mas.length + " элементов: "  + (endTime - startTime));
    }
}

