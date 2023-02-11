const express = require('express')
const app = express()
const port = 8080

app.use(express.json())

app.get('/hello', (req, res) => {
    res.send('Hello')
})

const q = []

function contains(s) {
    for (const v of q) {
        if (v === s) return true
    }
    return false
}

app.post('/pushQueue', (req, res) => {
    if (!req.body.content) {
        res.status(500).send('Not Valid Request').end()
        return
    }

    if (contains(req.body.content))
    {
        res.status(409).send('duplicated').end()
        return
    }
    q.push(req.body.content)
    res.status(200).end()
})

app.get('/getQueue', (req, res) => {
    res.json(q).end()
})

app.listen(port, () => {
    console.log(`listening on port ${port}`)
})