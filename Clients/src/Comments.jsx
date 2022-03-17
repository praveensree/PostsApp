import React, { Component } from 'react';
import axios from 'axios';
var list={}
export class Comments extends Component {
    constructor(props) {
        super(props)

        this.state = {
            postId: this.props.match.params.postId,
           post:[],
            List: []
        }
        
    }
    getPostbyId = (postId) => {
        axios.get("http://localhost:60438/api/SocialPost/"+postId).then((response) => {

            this.setState({ post: response.data });
            
        }, []);
    }

    getComments = (postId) => {
        axios.get("http://localhost:60438/api/Comments/"+postId).then((response) => {

            this.setState({ List: response.data });
            list=this.state.List

        }, []);
    }
  

    componentDidMount(){
        this.getPostbyId(this.state.postId);
        this.getComments(this.state.postId);
        
    }

  
  render() {
    return (
      <div>
        <h4>{this.state.post.postName}</h4>
          <h4>{this.state.post.postDescription}</h4>
          <div>
              { 
                  this.state.List.map(list=>
                      <ul key={list.commentId}>   
                          <li>{list.commentDetail}</li>
                      </ul>
                  )}
          </div>
      </div>
    )
  }
}

export default Comments