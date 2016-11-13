//
//  FirstViewController.swift
//  xm2 Native
//
//  Created by Yury Nevalenny on 13/11/2016.
//  Copyright © 2016 Rahmobile. All rights reserved.
//

import UIKit
import SwiftyJSON

class FirstViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    @IBOutlet weak var tableView: UITableView!
    var cellId:String = "ItemCell"
    var items: Array<JSON>? = nil
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        
        if let path = Bundle.main.path(forResource: "MOCK_DATA", ofType: "json")
        {
            do {
                let data = try Data(contentsOf: URL(fileURLWithPath: path), options: .alwaysMapped)
                let jsonObj = JSON(data: data)
                if jsonObj != JSON.null {
                    items = jsonObj.arrayValue
                } else {
                    print("Could not get json from file, make sure that file contains valid json.")
                }
            } catch let error {
                print(error.localizedDescription)
            }
            
            tableView.register(UITableViewCell.self, forCellReuseIdentifier: cellId)
            tableView.delegate = self
            tableView.dataSource = self
        }

    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return items?.count ?? 0
    }

    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        // cell selected code here
    }
    
    @available(iOS 2.0, *)
    public func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let item = items?[indexPath.row]
        let cell:UITableViewCell = tableView.dequeueReusableCell(withIdentifier: cellId)! as UITableViewCell
        
        let captionText = (item?["first_name"].stringValue ?? "") + " " + (item?["last_name"].stringValue ?? "")
        
        cell.textLabel?.text = captionText
        
        let pictureString = String((item?["picture"].stringValue ?? "").characters.dropFirst(22))
        
        let dataDecoded:Data = Data(base64Encoded: pictureString, options: NSData.Base64DecodingOptions(rawValue: 0))!
        
        cell.imageView?.image = UIImage(data: dataDecoded)!
        return cell
    }
}

