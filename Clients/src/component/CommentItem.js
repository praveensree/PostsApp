import React from 'react';
import {Card,Button, Modal, ModalHeader, ModalBody} from 'reactstrap';
import EditComment from './EditComment';

class CommentItem extends React.Component {
	state=
	{
		modal:false,
		commentDetail:"",
		
	}
	toggle = () =>{
		this.setState({modal : !this.state.modal})
	}
	updateComment =  (commentId,commentDetail) =>{
		
		this.props.updateComment(commentId, commentDetail);
		this.toggle();
	  };
	
	render() {
		 const {postId,commentId,commentDetail} = this.props.comment;
		return (
			<Card>
			<div className="card bg-light mb-3" style={{width: '25rem', margin:'auto'}}>
			  <div className="card-header"></div>
			  <div className="card-body">
				  <span>
			    <p className="card-text">{commentDetail}</p>
				<br/>
				<a href="#" onClick={this.toggle}>edit</a>
					<Modal isOpen={this.state.modal} toggle={this.toggle} >
					<ModalHeader toggle={this.toggle}>Edit Comment</ModalHeader>
					<ModalBody>
					<EditComment commentDetail={this.props.comment.commentDetail} commentId={this.props.comment.commentId} updateComment={this.updateComment}/>
					</ModalBody>
						</Modal>
				</span>
			  </div>
			</div>
			</Card>
		);
	}
}

export default CommentItem;