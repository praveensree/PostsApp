import React, { Component } from 'react';

import axios from 'axios';
let list={}
export class Comments extends Component {
    constructor(props) {
        super(props)

        this.state = {
            postId: this.props.postId,
           post:[],
            List: []
        }
        
    }
 

    getComments = (postId) => {
        axios.get("http://localhost:60438/api/Comments/"+postId).then((response) => {

            this.setState({ List: response.data });
            list=this.state.List

        }, []);
    }
  
    viewComment(id){
        this.props.history.push(`/ViewComment/${id}`);
    }

    componentDidMount(){
     
        this.getComments(this.state.postId);
        
    }

  
  render() {
    return (
      <div>
        
          <div>
              { 
                  this.state.List.map(list=>
                      <ul key={list.commentId}>   
                          <li>{list.commentDetail}
                          <button className="button-7" onClick={ () => this.viewComment(list.commentId)}>edit</button>
                          </li>
                          
                      </ul>
                  )}
          </div>
      </div>
    )
  }
}

export default Comments