package com.kevinzonda.webdemo.dsa;

import java.util.*;

public class KQueue<T> extends ArrayList<T> implements Queue<T>, List<T> {
    @Override
    public boolean offer(T t) {
        super.add(super.size(), t);
        return true;
    }

    @Override
    public boolean add(T t) {
        super.add(super.size(), t);
        return true;
    }

    @Override
    public T remove() {
        if (super.size() > 0)
            return super.remove(0);
        return null;
    }

    @Override
    public T poll() {
        return null;
    }

    @Override
    public T element() {
        if (super.size() > 0)
            return super.get(0);
        return null;
    }

    @Override
    public T peek() {
        if (super.size() > 0)
            return super.get(0);
        return null;
    }
}
