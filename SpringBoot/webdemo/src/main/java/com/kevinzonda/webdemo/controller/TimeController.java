package com.kevinzonda.webdemo.controller;

import org.springframework.http.HttpStatus;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
public class TimeController {
    @RequestMapping("/hello")
    @ResponseBody
    public ResponseEntity<String> sayHello()
    {
        return new ResponseEntity<>("Hello", HttpStatus.OK);
    }
}
