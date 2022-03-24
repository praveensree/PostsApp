import React, { Component } from 'react'
import axios from 'axios';


export class ViewComment extends Component {
    constructor(props) {
        super(props)

        this.state = {
            CommentId: this.props.match.params.commentId,
            comment:'',
            postId:''
        }
        this.handleFieldChange = this.handleFieldChange.bind(this);
    }
    getCommentById = (id) => {
        axios.get("http://localhost:60438/api/Comments/CommentbyId/"+id).then((response) => {
                let res= response.data
            this.setState({ comment: res.commentDetail,postId:res.postId});
            
        }, []);
    }
    updateCommentById=(id)=>{
        var msg = {
            commentDetail: this.state.comment
        }
        axios.put('http://localhost:60438/api/Comments/'+id, msg
        )
            .then(res => {
                let resp = res.data
                this.props.history.push(`/Comments/${resp.postId}`)
            })
    }
    handleFieldChange= (event) => {
        this.setState({comment: event.target.value});
    }
    componentDidMount(){
        this.getCommentById(this.state.CommentId);
        
        
    }
  render() {
    return (
      <div>
          <input type="text" name="comment"  className="search-boxss" onChange={this.handleFieldChange} value={this.state.comment}/>
          <button className="button-7" onClick={ () => this.updateCommentById(this.state.CommentId)}>save</button>
          <button className="button-25" onClick={ () => this.props.history.push(`/Comments/${this.state.postId}`)}>back</button>

      </div>
    )
  }
}

export default ViewComment