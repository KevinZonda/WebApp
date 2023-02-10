package com.kevinzonda.webdemo.controller;

import com.kevinzonda.webdemo.dsa.KQueue;
import com.kevinzonda.webdemo.model.PushQueueModel;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import java.util.List;
import java.util.Objects;
import java.util.Queue;

@Controller
public class QueueController {
    private Queue<String> _queue;

    public QueueController() {
        _queue = new KQueue<>();
    }

    @GetMapping("/getQueue")
    public ResponseEntity<List<String>> getQueueContent() {
        return new ResponseEntity<>((List<String>)_queue, HttpStatus.OK);
    }

    @PostMapping("/pushQueue")
    public ResponseEntity<String> postPushQueue(@RequestBody PushQueueModel<String> qm) {
        if (qm == null) return new ResponseEntity<>("null val", HttpStatus.BAD_REQUEST);
        if (_queue.contains(qm.getContent()))
            return new ResponseEntity<>("duplicated", HttpStatus.CONFLICT);
        _queue.add(qm.getContent());
        return new ResponseEntity<>("ok", HttpStatus.OK);

    }
}
