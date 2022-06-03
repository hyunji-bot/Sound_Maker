
import tensorflow.compat.v1 as tf
from IPython.display import display, Audio
import numpy as np
tf.disable_v2_behavior()
####### Load the graph 이 부분을 onnx load 방식으로 바꾸어 주어야합니다. ####################
tf.reset_default_graph()
### 여기 아래 수정. 같은 곳으로 ###
saver = tf.train.import_meta_graph('C:/Users/9898h/SoundMaker/model/infer.meta')
graph = tf.get_default_graph()
sess = tf.InteractiveSession()
### 여기 아래 수정. 같은 곳으로 ###
saver.restore(sess, 'C:/Users/9898h/SoundMaker/model/model.ckpt-2512')
###########################################################################################
# Create 50 random latent vectors z
_z = (np.random.rand(50, 100) * 2.) - 1

# Synthesize G(z)
z = graph.get_tensor_by_name('z:0')
G_z = graph.get_tensor_by_name('G_z:0')
_G_z = sess.run(G_z, {z: _z})

# Play audio in notebook
#display(Audio(_G_z[0, :, 0], rate=4000))
### 음성파일 저장 위치 Unity project 안에 ###
with open('C:/Users/9898h/SoundMaker/Assets/Resources/test.wav', 'wb') as f:
    f.write(Audio(_G_z[0, :, 0], rate=4000).data)
