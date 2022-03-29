import React from 'react' ;
import axios from 'axios';
import CommentItem from './CommentItem';
import  PropTypes from 'prop-types';
import { Button,Card} from 'reactstrap';
 import ReactDOM from 'react-dom';

 export class Comments extends React.Component {

	state=
	{
		comments : [],
		commentDetail:""
	}
	getComments(){
		axios
		.get("http://localhost:60438/api/Comments/"+ this.props.postId)
		.then(res => this.setState({ comments: res.data }));	
	}

	componentDidMount() {
		this.getComments()
   	
   }
   updateComment =  (commentId, commentDetail) =>{
    var cmt={
      commentDetail:commentDetail
    }
   axios.put('http://localhost:60438/api/Comments/'+commentId,cmt)
   .then(res => this.getComments()
   );
  };

  onChange = (e) => this.setState({[e.target.name]: e.target.value});

  addComment = (e) => {
    e.preventDefault();
    var comment={
		postId: this.props.postId,
		commentDetail: this.state.commentDetail
	   }
	   axios.post("http://localhost:60438/api/Comments",comment)
	   .then(res => this.setState({ comments: 
		[...this.state.comments, res.data]}));
    this.setState({commentDetail:""})    
    
	
  }
  render() {
		
		return(
			<div>
          {
		 this.state.comments.map((comment) => (
			<CommentItem key={comment.commentId} comment={comment} updateComment={this.updateComment}/>
			))
		}
		<div className="card bg-light mb-3" style={{width: '25rem', margin:'auto'}}>
			<div className="card-header">Write a comment ...</div>
			  <div className="card-body">		 
				<p><textarea type="text" name="commentDetail" rows="1" cols="45" placeholder=" Comment ..." value={this.state.commentDetail} onChange={this.onChange} /></p>
				<p><Button onClick={this.addComment} >Post</Button></p>
			</div>
			</div>
		</div>
		 );
	}
}



export default Comments;