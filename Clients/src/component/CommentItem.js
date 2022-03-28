import React from 'react';
import {Card,Button, Modal, ModalHeader, ModalBody} from 'reactstrap';
import EditComment from './EditComment';

class CommentItem extends React.Component {
	state=
	{
		modal:false,
		commentDetail:""
	}
	toggle = () =>{
		this.setState({modal : !this.state.modal})
	}
	
	render() {
		 const {postId,commentId,commentDetail} = this.props.comment;
		return (
			<Card>
			<div class="card bg-light mb-3" style={{width: '25rem', margin:'auto'}}>
			  <div class="card-header"></div>
			  <div class="card-body">
				  <span>
			    <p class="card-text">{commentDetail}</p>
				<br/>
				<a href="#" onClick={this.toggle}>edit</a>
					<Modal isOpen={this.state.modal} toggle={this.toggle} >
					<ModalHeader toggle={this.toggle}>Edit Comment</ModalHeader>
					<ModalBody>
					<EditComment commentDetail={this.props.comment.commentDetail} commentId={this.props.comment.commentId} updateComment={this.props.updateComment}/>
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