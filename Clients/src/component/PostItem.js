import React from 'react';

import Comments from './Comments';
import EditPost from './EditPost';
import { BrowserRouter as Router} from 'react-router-dom';
import { Button, Modal, ModalHeader, ModalBody } from 'reactstrap';
import 'font-awesome/css/font-awesome.min.css';

export class PostItem extends React.Component {

	state = {
		postmodal: false,
		modal: false,
		toggleLike: false,
		toggleHeart: false
	};
	toggle = () => {
		this.setState({ modal: !this.state.modal })
	}
	posttoggle = () => {
		this.setState({ postmodal: !this.state.postmodal })
	}
	setLikeButton = (postId) => {

		this.setState({ toggleLike: !this.state.toggleLike })
		this.props.likes(this.state.toggleLike, postId)
	}
	setHeartButton = (postId) => {

		this.setState({ toggleHeart: !this.state.toggleHeart })
		this.props.hearts(this.state.toggleHeart, postId)
	}


	updatePost = (postId, postName, postDescription) => {
		this.props.updatePost(postId, postName, postDescription)
		this.posttoggle();
	}



	render() {
		const { postId, postName, postDescription, likes, hearts } = this.props.post;
		return (
			<Router>
				<div class="card border-primary mb-3" style={{ width: '40rem', margin: 'auto' }}>
					<div class="card-header">
					</div>
					<div class="card-body">
						<h4 class="card-title">{postName}</h4>
						<span>
							<p class="card-text">{postDescription}<span>
								<a href="#" onClick={this.posttoggle}>   <i className="fa fa-edit" /></a>
							</span></p>
						</span>

						<span>
							<Button className="button-7" onClick={this.setLikeButton.bind(this, postId)} >{!this.state.toggleLike ? "👍" : "👎"}</Button>  Likes|: {likes} &nbsp;&nbsp;&nbsp;
						</span>
						<span>
							<Button className="button-7" onClick={this.setHeartButton.bind(this, postId)} >{!this.state.toggleHeart ? "❤️" : "💔"}</Button> Hearts|: {hearts}&nbsp;&nbsp;&nbsp;
						</span>
						<a href="#" onClick={this.toggle}> &nbsp;&nbsp;&nbsp;Comments</a>
						<Modal isOpen={this.state.modal} toggle={this.toggle} >
							<ModalHeader toggle={this.toggle}>Comments</ModalHeader>
							<ModalBody>
								<Comments postId={this.props.post.postId} editcomment={this.editComment} />
							</ModalBody>
						</Modal>
					</div>

					<Modal isOpen={this.state.postmodal} posttoggle={this.posttoggle} >
						<ModalHeader toggle={this.posttoggle}>Post</ModalHeader>
						<ModalBody>
							<EditPost postId={this.props.post.postId} postName={this.props.post.postName} postDescription={this.props.post.postDescription} updatePost={this.updatePost} />
						</ModalBody>
					</Modal>
				</div>
			</Router>
		);
	}
}


export default PostItem;