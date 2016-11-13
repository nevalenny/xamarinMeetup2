//
//  SecondViewController.swift
//  xm2 Native
//
//  Created by Yury Nevalenny on 13/11/2016.
//  Copyright © 2016 Rahmobile. All rights reserved.
//

import UIKit

class SecondViewController: UIViewController {
    @IBOutlet weak var arithmeticLabel: UILabel!
    @IBOutlet weak var collectionsLabel: UILabel!
    @IBOutlet weak var stringsLabel: UILabel!
    @IBOutlet weak var calculateButton: UIButton!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.

    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBAction func Calculate(_ sender: Any) {
        DispatchQueue.global(qos: .background).async {
            let mathModel = MathModel()
            mathModel.calculate()
            
            DispatchQueue.main.async {
                self.arithmeticLabel.text = "Arithmetic: "+mathModel.arithmeticPerformance
                self.collectionsLabel.text = "Collections: "+mathModel.collectionsPerformance
                self.stringsLabel.text = "Strings: "+mathModel.stringsPerformance
            }
        }
    }
}

