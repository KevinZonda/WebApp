package main

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

var q []string

type PushQueueModel struct {
	Content string `json:"content"`
}

func containsKey(v string) bool {
	if len(q) == 0 {
		return false
	}
	for _, qv := range q {
		if qv == v {
			return true
		}
	}
	return false
}

func main() {
	r := gin.Default()
	r.GET("/hello", func(c *gin.Context) {
		c.String(http.StatusOK, "Hello")
	})
	r.GET("/getQueue", func(c *gin.Context) {
		// default, a slice as string will be nil
		// however, [] is required behaviour
		if q == nil {
			c.String(http.StatusOK, "[]")
			return
		}
		c.JSON(http.StatusOK, q)
	})
	r.POST("/pushQueue", func(c *gin.Context) {
		var pm PushQueueModel
		err := c.ShouldBindJSON(&pm)
		if err != nil {
			// bind failed!
			c.String(http.StatusBadRequest, "Not Valid Request!")
			return
		}
		if containsKey(pm.Content) {
			c.String(http.StatusConflict, "duplicated")
			return
		}
		q = append(q, pm.Content)
		c.String(http.StatusOK, "OK")
	})
	r.Run("localhost:8080")
}
