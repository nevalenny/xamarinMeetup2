//
//  MathModel.swift
//  xm2 Native
//
//  Created by Yury Nevalenny on 14/11/2016.
//  Copyright © 2016 Rahmobile. All rights reserved.
//

import Foundation

class MathModel {
    public var arithmeticPerformance: String = ""
    public var collectionsPerformance: String = ""
    public var stringsPerformance: String = ""
    let repetitions = 1
    
    public func calculate()
    {
        calcArithmetic ()
        calcCollections ()
        calcStrings ()
    }
    
    func calcArithmetic ()
    {
        var arithmetic: Double = 0
        
        for _ in 0..<repetitions
        {
            let start = DispatchTime.now()
            
            var pans : Int = 0
            var primes : Int = 0
            var foo : Double = 0
            
            for i in 0..<12345
            {
                if isPandigital(n: i) { pans+=1 }
                
                if isPrime(n: i) { primes+=1 }
                
                foo += calculateFoo(n: i)
            }
            
            let end = DispatchTime.now()
            let nanoTime = end.uptimeNanoseconds - start.uptimeNanoseconds
            let timeInterval = Double(nanoTime) / 1_000_000
            
            arithmetic += timeInterval
        }
        
        arithmetic /= Double(repetitions)
        arithmeticPerformance = String(Int(arithmetic)) + " ms"
    }
    
    func calcCollections ()
    {
        var collections: Double = 0
        
        for _ in 0..<repetitions
        {
            let start = DispatchTime.now()
            
            
            var list = Array<FooContainer>(); //let's don't specify initial capacity
            for i in 0..<1000000
            {
                var f = FooContainer()
                f._x=i
                f._y=i
                list.append(f)
            }
            
            var filteredList = Array<FooContainer>()
            for i in 0..<list.count
            {
                if list[i].Sum() % 2 == 0 {
                    filteredList.append(list[i])
                }
            }
            
            let end = DispatchTime.now()
            let nanoTime = end.uptimeNanoseconds - start.uptimeNanoseconds
            let timeInterval = Double(nanoTime) / 1_000_000
            
            collections += timeInterval
        }
        
        collections /= Double(repetitions)
        collectionsPerformance = String(Int(collections)) + " ms"
    }
    
    func calcStrings ()
    {
        var strings: Double = 0
        
        for _ in 0..<repetitions
        {
            let start = DispatchTime.now()
            
            var result = ""
            for i in 0..<100000
            {
                result.append(String(i))
            }
            
            let index = result.index(result.startIndex, offsetBy: 1000)
            result = result.substring(from: index)
            result = result.replacingOccurrences(of: "10", with: "")
            let containsSubstring = result.contains("123")
            let parts = result.components(separatedBy: "2")
            let length = parts.count
            
            let end = DispatchTime.now()
            let nanoTime = end.uptimeNanoseconds - start.uptimeNanoseconds
            let timeInterval = Double(nanoTime) / 1_000_000
            
            strings += timeInterval
        }
        
        strings /= Double(repetitions)
        stringsPerformance = String(Int(strings)) + " ms"
    }
    
    func isPrime(n:Int) -> Bool
    {
        if n % 2 == 0 { return false }
        
        var i = 3
        while i*i<=n {
            i+=3
            if n % i == 0 { return false }
        }
        
        return true;
    }
    
    func isPandigital(n: Int) -> Bool
    {
        var index = n
        var count = 0
        var digits = 0
        var digit = 0
        var bit = 0
        
        repeat
        {
            digit = index % 10;
            if digit == 0 { return false }
            bit = 1 << digit
    
            let check = digits | bit
            if digits == check { return false }
            digits = check
    
            count += 1
            index /= 10
        } while (n > 0)
        
        return (1 << count) - 1 == digits >> 1;
    }
    
    func calculateFoo(n : Int) -> Double
    {
        var a = 1.0
        for _ in 0..<n
        {
            a = a * 1.123456789101112 / Double(n)
        }
        
        return a
    }
}

struct FooContainer
{
    public var _x = 0
    public var _y = 0
    
    public func Sum () -> Int
    {
        return _x + _y
    }
}
